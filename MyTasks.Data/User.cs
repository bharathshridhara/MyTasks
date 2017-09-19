using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyTasks.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyTasks.Data
{
    public class AppUser : IdentityUser
    {
        private string _email;
        /* identity field from database */
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long AppUserId { get; set; }

        [Required]
        public bool Internal { get; set; }

        public string FullName { get; set; }

        public string UserEmail { get { return _email; } set { _email = Email; } }

        public ICollection<ToDo> Tasks { get; set; }

        public AppUser()
            : base()
        {
            Internal = false;
        }

        public AppUser(string userName)
            : base(userName)
        {
            Internal = false;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }


    }
}