namespace Infrastructure.Models
{

    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class AppUser : IdentityUser
    {
        public AppUser()
        {

        }

        [MaxLength(256)]
        public string Address { get; set; }

        [MaxLength(64)]
        public string FirstName { get; set; }

        [MaxLength(64)]
        public string LastName { get; set; }

        [
           // Required, 
            MaxLength(32)]
        public string Town { get; set; }
       
    }
}