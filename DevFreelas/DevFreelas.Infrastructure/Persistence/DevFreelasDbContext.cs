using DevFreelas.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreelas.Infrastructure.Persistence
{

    public class DevFreelasDbContext : DbContext
    {
        public DevFreelasDbContext(DbContextOptions<DevFreelasDbContext> options) : base(options)
        {

        }


        public DbSet<Projects> Projects { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<UserSkill> UserSkills { get; set; }

        public DbSet<ProjectComment> ProjectComments { get; set; }
    }

}
