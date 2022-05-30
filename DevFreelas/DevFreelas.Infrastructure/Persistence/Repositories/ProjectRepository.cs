using DevFreelas.Core.Entities;
using DevFreelas.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreelas.Infrastructure.Persistence.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DevFreelasDbContext _dbContext;
        private readonly string _connectionString;

        public ProjectRepository(DevFreelasDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelasCs");
        }

        public async Task<List<Projects>> GetAll()
        {
            return await _dbContext.Projects.ToListAsync();
        }
    }    
}
