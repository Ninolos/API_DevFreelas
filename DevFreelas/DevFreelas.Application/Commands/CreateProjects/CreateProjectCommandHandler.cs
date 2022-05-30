using DevFreelas.Core.Entities;
using DevFreelas.Core.Repositories;
using DevFreelas.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelas.Application.Commands.CreateProjects
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        private readonly IProjectRepository _projectRepository;

        public CreateProjectCommandHandler(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Projects(request.Title, request.Description, request.IdClient, request.IdFreelancer, request.TotalCost);

            await _projectRepository.AddAsync(project);

            return project.Id;
        }
    }
}
