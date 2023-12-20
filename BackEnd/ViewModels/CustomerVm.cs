namespace BackEnd.ViewModels
{
    public class CustomerVm
    {
        public string Id { get; set; } = string.Empty;
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int SubscriptionState { get; set; }
        public int InvoiceNumbers { get; set; }
    }
}
