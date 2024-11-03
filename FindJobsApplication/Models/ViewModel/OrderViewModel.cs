namespace FindJobsApplication.Models.ViewModel
{
    public class OrderViewModel
    {
        public int? JobServiceId { get; set; }
    }

    public class OrderPaymentViewModel
    {
        public decimal TotalPrice { get; set; }
        public string? paymentMethod { get; set; }
        public string orderId { get; set; }
    }
}
