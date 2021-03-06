using DevFreelas.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreelas.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);

        Task<User> GetUserByEmaulAndPasswordAsync(string email, string passwordHash);
    }
}
