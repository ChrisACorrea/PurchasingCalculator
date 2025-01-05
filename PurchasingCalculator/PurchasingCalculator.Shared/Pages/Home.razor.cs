using Microsoft.AspNetCore.Components;
using PurchasingCalculator.Shared.Services;

namespace PurchasingCalculator.Shared.Pages;
public partial class Home : ComponentBase
{
    public Home(IFormFactor formFactor)
    {
        FormFactor = formFactor;
    }
    public IFormFactor FormFactor { get; set; }
    private string factor => FormFactor.GetFormFactor();
    private string platform => FormFactor.GetPlatform();
}
