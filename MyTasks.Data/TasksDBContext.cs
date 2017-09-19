using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTasks.Data
{
    public class TasksDBContext : IdentityDbContext<AppUser>
    {
        public TasksDBContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<ToDo> ToDos { get; set; }

        public static TasksDBContext Create()
        {
            return new TasksDBContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUser>().ToTable("User");
            modelBuilder.Entity<AppUser>().ToTable("User");

            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("User_Claim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("User_Login");
            modelBuilder.Entity<IdentityUserRole>().ToTable("User_Role");
        }

        
    }

    

}
