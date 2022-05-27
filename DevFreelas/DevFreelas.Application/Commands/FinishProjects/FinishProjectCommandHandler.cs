using DevFreelas.Infrastructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreelas.Application.Commands.FinishProjects
{
    public class FinishProjectCommandHandler : IRequestHandler<FinishProjectCommand, Unit>
    {
        private readonly DevFreelasDbContext _dbContext;

        public FinishProjectCommandHandler(DevFreelasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(FinishProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == request.Id);

            project.Finish();
            await _dbContext.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
