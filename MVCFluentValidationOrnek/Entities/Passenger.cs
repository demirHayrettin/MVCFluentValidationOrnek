using MVCFluentValidationOrnek.Enums;

namespace MVCFluentValidationOrnek.Entities
{
    public class Passenger
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? FirstName { get; set; }
        public string LastName { get; set; }
        public int TicketNumber { get; set; }

        public Gender? Gender { get; set; }
    }

  
}
