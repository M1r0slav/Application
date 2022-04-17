using Infrastructure.Models;

namespace Infrastructure.DTO
{
    public class UserInDTO : IMapTo<AppUser>
    {

        public virtual string Email { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }

    }
}
