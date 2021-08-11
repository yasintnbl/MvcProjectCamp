using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AbilityValidator : AbstractValidator<Ability>
    {
        public AbilityValidator()
        {
            RuleFor(x => x.AbiltyPoint).LessThan(101).WithMessage("100'ün üzerinde sayı giremezsiniz!");
            RuleFor(x => x.AbiltyName).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz");
            RuleFor(x => x.AbiltyPoint).NotEmpty().WithMessage("Bu alanı boş geçemezsiniz");
        }
    }
}
