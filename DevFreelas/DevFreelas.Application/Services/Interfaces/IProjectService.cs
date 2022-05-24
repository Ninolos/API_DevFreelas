using DevFreelas.Application.InputModels;
using DevFreelas.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreelas.Application.Services.Interfaces
{
    public interface IProjectService
    {
        //methods from ProjectsController
        List<ProjectViewModel> GetAll(string query);

        ProjectDetailsViewModel GetById(string query);

        int Create(NewProjectInputModel inputModel);

        void Update(UpdateProjectInputModel inputModel);

        void Delete(int id);

        void CreateComment(CreateCommentInputModel inputModel);

        void Start(int id);

        void Finish(int id);
    }
}
