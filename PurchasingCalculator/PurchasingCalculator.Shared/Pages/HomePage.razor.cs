using Microsoft.AspNetCore.Components;

namespace PurchasingCalculator.Shared.Pages;
public partial class HomePage : ComponentBase
{
    private NavigationManager Navigation { get; init; }

    public HomePage(NavigationManager navigation)
    {
        Navigation = navigation;
    }

    private void NavigateToCalculationPage()
    {
        Navigation.NavigateTo("purchase");
    }

    private void NavigateToSavedPurchases()
    {
        Navigation.NavigateTo("purchases");
    }
}
