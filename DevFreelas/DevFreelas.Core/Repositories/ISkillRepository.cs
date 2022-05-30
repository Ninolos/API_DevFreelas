using DevFreelas.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreelas.Core.Repositories
{
    public interface ISkillRepository
    {
        Task<List<SkillDTO>> GetAllAsync();
    }
}
