using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreelas.Application.InputModels
{
    public class NewProjectInputModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public int IdClient { get; set; }

        public int IdFreelancer { get; set; }

        public decimal TotalCost { get; set; }
    }
}
