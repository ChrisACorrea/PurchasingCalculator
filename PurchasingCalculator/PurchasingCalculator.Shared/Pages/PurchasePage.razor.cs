using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using PurchasingCalculator.Shared.Entities;
using System.Globalization;

namespace PurchasingCalculator.Shared.Pages;
public partial class PurchasePage : ComponentBase
{
    public CultureInfo _currentCulture = CultureInfo.GetCultureInfo("pt-BR");
    private bool _isInvalidForm = true;
    private EditContext? editContext;

    private MudNumericField<decimal> _unitPriceField = null!;
    private MudNumericField<float> _quantityField = null!;

    private readonly Purchase _currentPurchase = new();

    [SupplyParameterFromForm]
    private PurchaseItem? EditingItem { get; set; }

    protected override void OnInitialized()
    {
        CreateNewPurchaseItem();
        editContext = new(EditingItem!);
        editContext.OnFieldChanged += HandleFieldChanged;
    }

    private void AddItemInPurchase()
    {
        _currentPurchase.AddItem(EditingItem!);
        ClearPurchase();
    }

    private async void ClearPurchase()
    {
        CreateNewEditContext();
        StateHasChanged();
        await _unitPriceField.FocusAsync();
    }

    private void CreateNewPurchaseItem()
    {
        EditingItem = new() { Quantity = 1.0f };
    }

    private void CreateNewEditContext()
    {
        Dispose();
        CreateNewPurchaseItem();
        editContext = new(EditingItem!);
        editContext.OnFieldChanged += HandleFieldChanged;
    }

    private string GetAdornmentPriceField()
        => _currentCulture.NumberFormat.CurrencySymbol;

    private bool HasDecimalSeparatorInQuantityField() =>
        EditingItem!.Quantity.ToString().Contains(_currentCulture.NumberFormat.NumberDecimalSeparator);

    private string GetAdornmentQuantityField()
        => HasDecimalSeparatorInQuantityField() ? "Kg" : "Un";

    private string GetAdornmentQuantityFormat()
        => HasDecimalSeparatorInQuantityField() ? "N3" : string.Empty;

    private void HandleFieldChanged(object? sender, FieldChangedEventArgs e)
    {
        if (editContext is not null)
        {
            _isInvalidForm = !editContext.Validate();
            StateHasChanged();
        }
    }

    public void Dispose()
    {
        if (editContext is not null)
        {
            editContext.OnFieldChanged -= HandleFieldChanged;
        }
    }
}
