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

namespace DevFreelas.Application.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly DevFreelasDbContext _dbContex;

        public ProjectService(DevFreelasDbContext dbContext)
        {
            _dbContex = dbContext;
        }

        public int Create(NewProjectInputModel inputModel)
        {
            var project = new Projects(inputModel.Title, inputModel.Description, inputModel.IdClient, inputModel.IdFreelancer, (int)inputModel.TotalCost);

            _dbContex.Projects.Add(project);

            return project.Id;
        }

        public void CreateComment(CreateCommentInputModel inputModel)
        {
            var comment = new ProjectComment(inputModel.Content, inputModel.IdProject, inputModel.IdUser);

            _dbContex.ProjectComments.Add(comment);
        }

        public void Delete(int id)
        {
            var project = _dbContex.Projects.SingleOrDefault(p => p.Id == id);

            project.Cancel();
        }

        public void Finish(int id)
        {
            var project = _dbContex.Projects.SingleOrDefault(p => p.Id == id);

            project.Finish();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var project = _dbContex.Projects;

            var projectsViewModel = project
                .Select(p => new ProjectViewModel(p.Id, p.Title, p.CreatedAt))
                .ToList();

            return projectsViewModel;
        }

        public ProjectDetailsViewModel GetById(int id)
        {
            var project = _dbContex.Projects.SingleOrDefault(p => p.Id == id);

            if (project == null) return null;

            var projectDetailsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartedAt,
                project.FinishedAt
                
                );

            return projectDetailsViewModel;
        }

        public void Start(int id)
        {
            var project = _dbContex.Projects.SingleOrDefault(p => p.Id == id);

            project.Start();
        }

        public void Update(UpdateProjectInputModel inputModel)
        {
            var project = _dbContex.Projects.SingleOrDefault(p => p.Id == inputModel.Id);

            project.Update(inputModel.Title, inputModel.Description, (int)inputModel.TotalCost);
        }
    }
}
