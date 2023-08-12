using Microsoft.AspNetCore.Components;

namespace PurchasingCalculator.SharedUI.Pages;

public partial class Index : ComponentBase
{
    [Inject]
    public NavigationManager Navigation { get; set; } = null!;

    public void GoToCalculationPage() =>
        Navigation.NavigateTo("calculation");
}