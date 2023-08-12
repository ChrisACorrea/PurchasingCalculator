
namespace PurchasingCalculator.Shared.Models;

public abstract class BaseModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreationDate { get; set; }
}
