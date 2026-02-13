namespace MOBILUX.Models;

public class Payment
{
    public string Id { get; set; } = "";
    public string PurchaseId { get; set; } = "";
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
}
