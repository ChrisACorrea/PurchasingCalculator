using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using PurchasingCalculator.Shared.Entities;
using System.Globalization;

namespace PurchasingCalculator.Shared.Pages;
public partial class PurchasePage : ComponentBase
{
    public CultureInfo _currentCulture = CultureInfo.GetCultureInfo("pt-BR");
    private EditContext? editContext;
    private bool _isInvalidForm = true;
    private bool _isEditing = false;

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

    private void SaveItem()
    {
        if (_isEditing)
        {
            UpdateItemInPurchase();
        }
        else
        {
            AddItemInPurchase();
        }
    }

    private void AddItemInPurchase()
    {
        _currentPurchase.AddItem(EditingItem!);
        ClearPurchase();
    }

    private void UpdateItemInPurchase()
    {
        _currentPurchase.UpdateItem(EditingItem!);
        ClearPurchase();
    }

    private void EditItemInPurchase(PurchaseItem item)
    {
        _isEditing = true;
        EditingItem = item.ShallowCopy();
        CreateNewEditContext();
    }

    private void RemoveItemFromPurchase(PurchaseItem item)
    {
        _currentPurchase.RemoveItem(item);
        StateHasChanged();
    }

    private async void ClearPurchase()
    {
        CreateNewPurchaseItem();
        CreateNewEditContext();
        StateHasChanged();
        _isInvalidForm = true;
        _isEditing = false;
        await _unitPriceField.FocusAsync();
    }

    private void CreateNewPurchaseItem()
    {
        EditingItem = new() { Quantity = 1.0f };
    }

    private void CreateNewEditContext()
    {
        Dispose();
        editContext = new(EditingItem!);
        editContext.OnFieldChanged += HandleFieldChanged;
    }

    private string GetAdornmentPriceField()
        => _currentCulture.NumberFormat.CurrencySymbol;

    private bool HasDecimalSeparatorInQuantityField(float value) =>
        value.ToString().Contains(_currentCulture.NumberFormat.NumberDecimalSeparator);

    private string GetAdornmentQuantityField(float value)
        => HasDecimalSeparatorInQuantityField(value) ? "Kg" : "Un";

    private string GetAdornmentQuantityFormat(float value)
        => HasDecimalSeparatorInQuantityField(value) ? "N3" : string.Empty;

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
