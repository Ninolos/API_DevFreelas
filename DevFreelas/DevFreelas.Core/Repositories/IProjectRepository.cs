using DevFreelas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreelas.Core.Repositories
{
    public interface IProjectRepository
    {
        Task<List<Projects>> GetAllAsync();

        Task<Projects> GetDetailsByIdAsync(int id);

        Task<Projects> GetByIdAsync(int id);

        Task AddAsync(Projects projects);

        Task StartAsync(Projects project);

        Task AddCommentAsync(ProjectComment projectComment);

        Task SaveChangesAsync();     
                
    }
}
