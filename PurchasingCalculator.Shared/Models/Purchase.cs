using System.Collections.ObjectModel;

namespace PurchasingCalculator.Shared.Models;

public class Purchase : BaseModel
{
    private readonly List<PurchaseItem> itemsList = new();
    public IReadOnlyList<PurchaseItem> Items => new ReadOnlyCollection<PurchaseItem>(itemsList);
    public decimal Total => itemsList.Sum(x => x.TotalPrice);
    public bool Completed { get; set; }

    public void AddItem(PurchaseItem item)
    {
        item.CreationDate = DateTime.Now;
        itemsList.Add(item);
    }

    public void RemoveItem(PurchaseItem item)
    {
        itemsList.Remove(item);
    }
}
