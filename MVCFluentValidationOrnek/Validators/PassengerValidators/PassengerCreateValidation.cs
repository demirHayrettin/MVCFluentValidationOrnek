using FluentValidation;
using MVCFluentValidationOrnek.Models;
using System.Drawing.Text;

namespace MVCFluentValidationOrnek.Validators.PassengerValidators
{
    public class PassengerCreateValidation : AbstractValidator<PassengerCreateVM>
    {
        public PassengerCreateValidation()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("Lütfen Boş Bırakmayın").MaximumLength(15).WithMessage("En fazla 15 karakter girebilirsiniz").MinimumLength(3).WithMessage("3 karakterden az giremezsiniz");
                 RuleFor(p => p.LastName).NotEmpty().WithMessage("Lütfen Boş Bırakmayın").MaximumLength(15).WithMessage("En fazla 15 karakter girebilirsiniz").MinimumLength(3).WithMessage("3 karakterden az giremezsiniz");
            RuleFor(p => p.TicketNumber).NotEmpty().WithMessage("Lütfen Boş Bırakmayın").Must(BeAnInt).WithMessage("Sadece tam sayı girebilirsiniz");
            RuleFor(p => p.Gender).NotEmpty().WithMessage("Lütfen Boş Bırakmayın");

            
        }
        private bool BeAnInt(string ticketNumber)
        {
            return int.TryParse(ticketNumber, out _);
        }

        
    }
}
