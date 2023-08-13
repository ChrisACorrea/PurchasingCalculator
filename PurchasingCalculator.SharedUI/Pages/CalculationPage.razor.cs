using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using PurchasingCalculator.Shared.Models;
using System.Globalization;

namespace PurchasingCalculator.SharedUI.Pages;

public partial class CalculationPage : ComponentBase
{
    public Purchase Purchase { get; set; } = new();
    public PurchaseItem EditingItem = new();

    private MudTextField<string> descriptionField = null!;
    private MudNumericField<decimal> priceField = null!;
    private MudNumericField<decimal> quantityField = null!;

    private void OnSubmit(EditContext context)
    {
        if (EditingItem.TotalPrice <= 0) return;

        Purchase.AddItem(EditingItem);
        ClearEditingItem();
    }

    public void ClearEditingItem()
    {
        EditingItem = new();
        StateHasChanged();
    }

    public static bool HasDecimalPoint(decimal number)
        => number.ToString().Contains(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
}
