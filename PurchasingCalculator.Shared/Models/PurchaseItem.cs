
namespace PurchasingCalculator.Shared.Models;

public class PurchaseItem : BaseModel
{
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; } = decimal.Zero;
    public decimal Quantity { get; set; } = decimal.One;
    public decimal TotalPrice => Price * Quantity;
}
