using DevFreelas.Core.Entities;
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
        private readonly DevFreelasDbContext _dbContext;

        public CreateProjectCommandHandler(DevFreelasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Projects(request.Title, request.Description, request.IdClient, request.IdFreelancer, request.TotalCost);

            await _dbContext.Projects.AddAsync(project);
            await _dbContext.SaveChangesAsync();

            return project.Id;
        }
    }
}
