using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTasks.Data
{
    public class TasksDBContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ToDo> ToDos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("Users");
            modelBuilder.Entity<ApplicationUser>().ToTable("Users");

            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("User_Claim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("User_Login");
            modelBuilder.Entity<IdentityUserRole>().ToTable("User_Role");
        }

    }

    

}
