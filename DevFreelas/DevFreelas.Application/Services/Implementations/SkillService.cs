using DevFreelas.Application.Services.Interfaces;
using DevFreelas.Application.ViewModels;
using DevFreelas.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreelas.Application.Services.Implementations
{
    public class SkillService : ISkillService
    {
        private readonly DevFreelasDbContext _dbContex;
        private readonly string _connectionString;

        public SkillService(DevFreelasDbContext dbContext, IConfiguration configuration)
        {
            _dbContex = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelasCs");
        }

        public List<SkillViewModel> GetAll()
        {
            var skills = _dbContex.Skills;

            var skillsViewModel = skills
                .Select(s => new SkillViewModel(s.Id, s.Description))
                .ToList();

            return skillsViewModel;
        }
    }
}
