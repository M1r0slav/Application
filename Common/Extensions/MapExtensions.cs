namespace Common.Extensions
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using AutoMapperConfiguration;
    using System.Linq;

    public static class MapExtensions
    {

        private static MapperConfiguration mapcfg;
        static MapExtensions()
        {

            mapcfg = new MapperConfiguration(mc =>
             {
                 mc.AddProfile(new MappingProfile());
             });
        }
        public static IQueryable<TDestination> To<TDestination>(this IQueryable query)
        {
            return query.ProjectTo<TDestination>(mapcfg);
        }
    }
}