using DevFreelas.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreelas.Application.Queries.GetUsers
{
    public class GetUsersQuery : IRequest<UserViewModel>
    {
        public GetUsersQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
