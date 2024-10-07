using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindJobsApplication.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }

        [Required]
        public DateTime IssueDate { get; set; }

        public decimal Amount { get; set; }

        public int EmployerId { get; set; }

        [ForeignKey("EmployerId")]
        public Employer Employer { get; set; }
    }

}
