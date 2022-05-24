using DevFreelas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreelas.Infrastructure.Persistence
{
  
    public class DevFreelasDbContext
    {
        public DevFreelasDbContext()
        {
            Projects = new List<Projects>
            {
                new Projects("My ASPNET Core Project 1", "My Description", 1, 1, 10000),
                new Projects("My ASPNET Core Project 2", "My Description", 1, 1, 20000),
                new Projects("My ASPNET Core Project 3", "My Description", 1, 1, 30000)
            };

            Users = new List<User>
            {
                new User("Jonathan Loth", "ninoloth@gmail.com", new DateTime(1995, 07, 20)),
                new User("Robert C Martin", "test1@gmail.com", new DateTime(1995, 01, 15)),
                new User("Anderson Sauberlich", "test2@gmail.com", new DateTime(1992, 07, 20))
            };

            Skills = new List<Skill>
            {
                new Skill(".NET Core"),
                new Skill("C#"),
                new Skill("SQL Server")
            };


    }
        public List<Projects> Projects { get; set; }

        public List<User> Users { get; set; }

        public List<Skill> Skills { get; set; }
    }
}
