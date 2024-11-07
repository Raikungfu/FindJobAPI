using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindJobsApplication.Models
{

    public enum PaymentStatus
    {
        Pending,
        Paid,
        Failed,
        Refunded
    }

    public enum OrderStatus
    {
        Pending,
        Accepted,
        Rejected,
        Completed
    }

    public enum PaymentMethod
    {
        VNPay,
        PayPal,
        PayOS
    }

    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public DateTime? OrderDate { get; set; } = DateTime.Now;

        public DateTime? DateFrom { get; set; }

        public DateTime? DateTo { get; set; }

        public int? JobServiceId { get; set; }
        
        [ForeignKey("JobServiceId")]
        public JobService JobService { get; set; }

        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;

        public PaymentMethod? PaymentMethod { get; set; }

        public DateTime? PaymentDate { get; set; }

        public string? PaymentRef { get; set; }

        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;
    }
}
