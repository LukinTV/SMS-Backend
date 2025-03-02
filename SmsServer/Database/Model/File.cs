using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SmsServer.Database.Model
{
    internal class File
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public required string Title { get; set; }

        [Required]
        public required string Extension { get; set; }

        [Required]
        public required DateTime UploadedOn { get; set; }

        [Required]
        public required byte[] Content { get; set; }

        [Required]
        public required Employee Uploadedby { get; set; }

        [InverseProperty("Attachment")]
        public required ICollection<News> UsedInNews { get; set; }
    }
}
