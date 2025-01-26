namespace PurchasingCalculator.Shared.Entities;
public class Purchase : BaseEntity
{
    private List<PurchaseItem> _items = [];
    public IReadOnlyList<PurchaseItem> PurchaseList => [.. _items];
    public decimal Total => _items.Sum((x) => x.SubTotal);

    public void AddItem(PurchaseItem item)
    {
        _items.Add(item);
    }

    public void RemoveItem(PurchaseItem item)
    {
        _items.Remove(item);
    }
}
