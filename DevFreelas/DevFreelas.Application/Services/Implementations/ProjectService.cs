using DevFreelas.Application.InputModels;
using DevFreelas.Application.Services.Interfaces;
using DevFreelas.Application.ViewModels;
using DevFreelas.Core.Entities;
using DevFreelas.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevFreelas.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelasDbContext _dbContext;
        private readonly string _connectionString;

        public ProjectService(DevFreelasDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelasCs");
        }                

       

        public List<ProjectViewModel> GetAll(string query)
        {
            var project = _dbContext.Projects;

            var projectsViewModel = project
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                .ToList();

            return projectsViewModel;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _dbContext.Projects
                .Include(p => p.Client)
                .Include(p => p.Freelancer)
                .SingleOrDefault(p => p.Id == id);

            if (project == null) return null;

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt,
                project.Client.FullName,
                project.Freelancer.FullName
                
                );

            return projectDetailsViewModel;
        }
       
    }
}
