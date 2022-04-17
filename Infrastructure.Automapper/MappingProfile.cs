namespace AutoMapperConfiguration
{
    using AutoMapper;
    using Infrastructure.DTO;
    using System;
    using System.Linq;
    using System.Text;
    public class MappingProfile : Profile
    {
        private readonly string confName = "con";
        private StringBuilder sb = new StringBuilder();
        public string MappingsAsString => sb.ToString().Trim();
        public MappingProfile()
        {
            var allTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes());

            CreateMapToMappings(allTypes);
            CreateMapFromMappings(allTypes);

            //CreateMap<UserInDTO, AppUser>();
          

            /* Example of making a custum mapping settings
            CreateMap<Product, ProductForManagingOutDto>()
                 .ForMember(d => d.ProductOrdersPending, opt => opt.MapFrom(s => s.ProductOrders.Count(po => po.Order.Status != Status.Finalised)))
                 .ForMember(d => d.OrderedQuantityPending, opt => opt.MapFrom(s => s.ProductOrders.Where(o => o.Order.Status != Status.Finalised).Sum(po => po.Quantity)))
                 .ForMember(d => d.ProductOrdersTotal, opt => opt.MapFrom(s => s.ProductOrders.Count()))
                 .ForMember(d => d.OrderedQuantityTotal, opt => opt.MapFrom(s => s.ProductOrders.Sum(po => po.Quantity)));
            */

        }

        private void CreateMapToMappings(System.Collections.Generic.IEnumerable<Type> allTypes)
        {
            Type[] sourseTypes = allTypes.Where(x => x.GetInterfaces()
                                         .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>)))
                                         .ToArray();
            foreach (Type sType in sourseTypes)
            {
                Type[] targetTypes = sType.GetInterfaces()
                                          .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>))
                                          .Select(x => x.GetGenericArguments().First())
                                          .ToArray();

                foreach (Type targetType in targetTypes)
                {
                    CreateMap(sType, targetType);
                    string txt = $"{confName}.CreateMap<{sType.FullName},{targetType.FullName}>();";
                    sb.AppendLine(txt);
                }
            }
        }
        private void CreateMapFromMappings(System.Collections.Generic.IEnumerable<Type> allTypes)
        {
            Type[] destTypes = allTypes.Where(x => x.GetInterfaces()
                                       .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                                       .ToArray();

            foreach (Type dType in destTypes)
            {
                Type[] sourceTypes = dType.GetInterfaces()
                                          .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>))
                                          .Select(x => x.GetGenericArguments().First())
                                          .ToArray();

                foreach (Type sType in sourceTypes)
                {
                    CreateMap(sType, dType);
                    string txt = $"{confName}.CreateMap<{sType.FullName},{dType.FullName}>();";
                    sb.AppendLine(txt);
                }
            }
        }
    }
}