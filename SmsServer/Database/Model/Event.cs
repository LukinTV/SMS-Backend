using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmsServer.Database.Model
{
    class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Description { get; set; }

        [Required]
        public required DateTime EventTime { get; set; }

        [Required]
        public required DateTime RegistrationTime { get; set; }

        public required Employee CreatedBy { get; set; }

        [Required]
        public required Employee ContactEmployee { get; set; }

        [InverseProperty("Event")]
        public required ICollection<EmployeeEvent> AttendedBy { get; set; }
    }
}
