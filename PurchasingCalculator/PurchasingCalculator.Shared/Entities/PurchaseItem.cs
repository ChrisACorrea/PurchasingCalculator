namespace PurchasingCalculator.Shared.Entities;
public class PurchaseItem : BaseEntity
{
    public string Description { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public float Quantity { get; set; } = 1.0f;
    public decimal SubTotal => UnitPrice * ((decimal)Quantity);
}
