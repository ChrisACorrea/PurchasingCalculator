using Microsoft.AspNetCore.Components;
using PurchasingCalculator.Shared.Models;
using System.Globalization;

namespace PurchasingCalculator.SharedUI.Pages;

public partial class CalculationPage : ComponentBase
{
    public Purchase Purchase { get; set; } = new();
    public PurchaseItem EditingItem = new();

    public void AddItem()
    {
        Purchase.AddItem(EditingItem);
        ClearEditingItem();
    }

    public void ClearEditingItem()
        => EditingItem = new();

    public bool HasDecimalPoint(decimal number)
        => number.ToString().Contains(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
}
