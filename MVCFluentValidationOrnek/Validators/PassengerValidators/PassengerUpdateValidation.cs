using FluentValidation;
using MVCFluentValidationOrnek.Models;
using System.Xml.Linq;

namespace MVCFluentValidationOrnek.Validators.PassengerValidators
{
    public class PassengerUpdateValidation : AbstractValidator<PassengerUpdateVM>
    {
        public PassengerUpdateValidation()
        {
            
            
                RuleFor(p => p.FirstName).NotEmpty().WithMessage("Lütfen Boş Bırakmayın").MaximumLength(15).WithMessage("En fazla 15 karakter girebilirsiniz").MinimumLength(3).WithMessage("3 karakterden az giremezsiniz").Must(BeValid).WithMessage("Özel karakter içeremez");
                RuleFor(p => p.LastName).NotEmpty().WithMessage("Lütfen Boş Bırakmayın").MaximumLength(15).WithMessage("En fazla 15 karakter girebilirsiniz").MinimumLength(3).WithMessage("3 karakterden az giremezsiniz").Must(BeValid).WithMessage("Özel karakter içeremez");
                RuleFor(p => p.TicketNumber).NotEmpty().WithMessage("Lütfen Boş Bırakmayın").Must(BeAnInt).WithMessage("Sadece tam sayı girebilirsiniz");
                RuleFor(p => p.Gender).NotEmpty().WithMessage("Lütfen Boş Bırakmayın");


        }
        private bool BeAnInt(string ticketNumber)
        {
            return int.TryParse(ticketNumber, out _);
        }

        private bool BeValid(string name)
        {
            var kontrol = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z ]+$");
            return kontrol.IsMatch(name);
        }


    }
}
