using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationsRules
{
    public class AbilityValidator : AbstractValidator<Ability>
    {
        public AbilityValidator()
        {
            //yetenek için validator gerekli miydi? who knows..
            //yetenek için skill yerine ability kullanmam ve tekrar düzeltmeye üşenmem asds
            RuleFor(x => x.AbilityName).NotEmpty().WithMessage("Yetenek adı alanını boş geçemezsin");
            RuleFor(x => x.AbilityValue).NotEmpty().WithMessage("Yetenek değerini boş geçemezsin");
            RuleFor(x => x.AbilityName).MinimumLength(3).WithMessage("Lütfen en az 3 karater girin.");
            RuleFor(x => x.AbilityName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayın");
            //burda yaptığım doğru mu? who knows..
           RuleFor(x => x.AbilityValue).LessThan(100).WithMessage("Lütfen 100 den büyük değer girmeyiniz");
        }
    }
}
