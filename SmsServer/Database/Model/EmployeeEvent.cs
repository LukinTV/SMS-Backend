using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmsServer.Database.Model
{
    class EmployeeEvent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public required Employee Employee { get; set; }

        [Required]
        public required Event Event { get; set; }

        [Required]
        public required DateTime RegisterTime { get; set; }
    }
}
