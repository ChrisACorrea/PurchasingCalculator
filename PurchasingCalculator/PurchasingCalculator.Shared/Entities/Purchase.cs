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

    public void UpdateItem(PurchaseItem item)
    {
        var index = _items.FindIndex((x) => x.Id == item.Id);
        if (index >= 0)
        {
            _items[index] = item;
        }
    }

    public void RemoveItem(PurchaseItem item)
    {
        _items.Remove(item);
    }
}
