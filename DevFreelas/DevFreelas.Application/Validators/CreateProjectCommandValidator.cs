using DevFreelas.Application.Commands.CreateProjects;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreelas.Application.Validators
{
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(p => p.Description)
                .MaximumLength(255)
                .WithMessage("Max length is 255");

            RuleFor(p => p.Title)
                .MaximumLength(30)
                .WithMessage("Max length is 30");
        }
    }
}
