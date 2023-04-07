using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationsRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı adresini boş geçemezsin");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konuyu boş geçemezsin");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajı boş geçemezsin");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi girin");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen 3 karakterden az değer girişi yapmayın");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Lütfen 100 karakterden fazla değer girişi yapmayın");
        }
    }
}
