using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FindJobsApplication.Models
{
    public enum JobServiceType
    {
        ForHire,
        ForSale,
        ForEmployee,
        ForEmployer,
        Service,
        Product,
        Subscription,
        Membership,
        Other
    }

    public class JobService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobServiceId { get; set; }

        public string ServiceName { get; set; }

        public string? Description { get; set; }
        
        public string? Image { get; set; }

        public decimal Price { get; set; }

        public double? Duration { get; set; }

        public int AdminId { get; set; }

        public JobServiceType jobServiceType { get; set; } = JobServiceType.Other;

        [ForeignKey("AdminId")]
        public Admin Admin { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}