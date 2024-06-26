using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTOs.Admin.Countries
{
    public class CountryEditDto
    {
        public string Name { get; set; }
    }


    public class CountryEditDtoValidator : AbstractValidator<CountryEditDto>
    {
        public CountryEditDtoValidator()
        {
            RuleFor(m => m.Name).NotNull().WithMessage("Name is required");
        }

    }
}
