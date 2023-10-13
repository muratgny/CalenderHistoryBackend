using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.FluentValidation
{
    public class CastoryValidator : AbstractValidator<Castory>
    {
        //All Castory item validation rules comes here
        public CastoryValidator() 
        {
            RuleFor(p => p.Name).MinimumLength(15).MaximumLength(250);
        }
    }
}
