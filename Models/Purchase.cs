namespace MOBILUX.Models;

public class Purchase
{
    public string Id { get; set; } = "";

    public string ProductName { get; set; } = "";

    public decimal TotalPrice { get; set; }

    public decimal RemainingBalance { get; set; }

    public DateTime PurchaseDate { get; set; }

    public string Status { get; set; } = "";
}
