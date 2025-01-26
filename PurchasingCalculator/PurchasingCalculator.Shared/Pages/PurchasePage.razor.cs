using Microsoft.AspNetCore.Components;
using MudBlazor;
using PurchasingCalculator.Shared.Entities;
using System.Globalization;

namespace PurchasingCalculator.Shared.Pages;
public partial class PurchasePage : ComponentBase
{
    public CultureInfo _currentCulture = CultureInfo.GetCultureInfo("pt-BR");

    private MudNumericField<decimal> _unitPriceField = null!;
    private MudNumericField<float> _quantityField = null!;

    private Purchase _currentPurchase = new();
    private PurchaseItem _editingItem = new();

    private void AddItemInPurchase()
    {
        _currentPurchase.AddItem(_editingItem);
        ClearPurchase();
    }

    private void ClearPurchase()
    {
        _editingItem = new() { Quantity = 1.0f };
        StateHasChanged();
        _unitPriceField.FocusAsync();
    }

    private string GetAdornmentPriceField()
        => _currentCulture.NumberFormat.CurrencySymbol;

    private bool HasDecimalSeparatorInQuantityField() =>
        _editingItem.Quantity.ToString().Contains(_currentCulture.NumberFormat.NumberDecimalSeparator);

    private string GetAdornmentQuantityField()
        => HasDecimalSeparatorInQuantityField() ? "Kg" : "Un";

    private string GetAdornmentQuantityFormat()
        => HasDecimalSeparatorInQuantityField() ? "N3" : string.Empty;
}
