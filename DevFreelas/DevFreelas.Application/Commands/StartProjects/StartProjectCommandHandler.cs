using DevFreelas.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelas.Application.Commands.StartProjects
{
    public class StartProjectCommandHandler : IRequestHandler<StartProjectCommand, Unit>
    {
        private readonly DevFreelasDbContext _dbContext;

        public StartProjectCommandHandler(DevFreelasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(StartProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

            project.Start();
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
