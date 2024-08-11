using MVCFluentValidationOrnek.Enums;

namespace MVCFluentValidationOrnek.Models
{
    public class PassengerListVM
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TicketNumber { get; set; }

        public Gender Gender { get; set; }
    }
}
