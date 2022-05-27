using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreelas.Application.Commands.UpdateProjects
{
    public class UpdateProjectCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int TotalCost { get; set; }
    }
}
