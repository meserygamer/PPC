using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace PPC
{
    public class UserContext : DbContext
    {
        public UserContext():base("TheBestEntities")
        {}
        public DbSet<Date_task> Date_Tasks { get; set; }
        public DbSet<Date_Users> Date_Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
