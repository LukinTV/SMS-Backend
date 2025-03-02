using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmsServer.Database.Model
{
    internal class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public required string EMail { get; set; }

        [Required]
        public required string Password { get; set; }

        [Required]
        public required string FirstName { get; set; }

        [Required]
        public required string LastName { get; set; }

        public required string TelephoneNumber { get; set; }

        public required DateTime BirthDay { get; set; }

        public required string SVNR { get; set; }

        public required long SamariterbundID { get; set; }

        public required long NNOEID { get; set; }

        [InverseProperty("UploadedBy")]
        public required ICollection<File> UploadedFiles { get; set; }

        [InverseProperty("CreatedBy")]
        public required ICollection<News> CreatedNews { get; set; }

        [InverseProperty("CreatedBy")]
        public required ICollection<Event> CreatedEvents { get; set; }

        [InverseProperty("ContactEmployee")]
        public required ICollection<Event> ContactInEvents { get; set; }

        [InverseProperty("Employee")]
        public required ICollection<EmployeeEvent> AttendsEvents { get; set; }
    }
}
