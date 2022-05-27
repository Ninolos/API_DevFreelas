using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreelas.Application.Commands.DeleteProjects
{
    public class DeleteProjectCommand : IRequest<Unit>
    {
        public int Id { get; private set; }

        public DeleteProjectCommand(int id)
        {
            Id = id;
        }
    }
}
