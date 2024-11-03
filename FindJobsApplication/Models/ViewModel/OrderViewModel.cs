namespace FindJobsApplication.Models.ViewModel
{
    public class OrderViewModel
    {
        public int? JobServiceId { get; set; }
    }

    public class OrderPaymentViewModel
    {
        public string? PaymentMethod { get; set; }
        public string OrderId { get; set; }
    }
}
