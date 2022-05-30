using Dapper;
using DevFreelas.Core.Entities;
using DevFreelas.Core.Repositories;
using Microsoft.Data.SqlClient;
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
       

        public async Task<List<Projects>> GetAllAsync()
        {
            return await _dbContext.Projects.ToListAsync();
        }

        public async Task<Projects> GetDetailsByIdAsync(int id)
        {
            return await _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Projects> GetByIdAsync(int id)
        {
            return await _dbContext.Projects.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task AddAsync(Projects projects)
        {
            await _dbContext.Projects.AddAsync(projects);
            await _dbContext.SaveChangesAsync();
        }

        public async Task StartAsync(Projects projects)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                var script = "UPDATE Projects SET Status = @status, StartedAt = @startedat WHERE Id = @id";

                await sqlConnection.ExecuteAsync(script, new { status = projects.Status, startedat = projects.StartedAt, projects.Id });
            }
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }        

        public async Task AddCommentAsync(ProjectComment projectComment)
        {
            await _dbContext.ProjectComments.AddAsync(projectComment);
            await _dbContext.SaveChangesAsync();
        }

    }    
}
