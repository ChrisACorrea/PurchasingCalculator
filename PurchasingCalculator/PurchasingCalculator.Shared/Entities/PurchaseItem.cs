using System.ComponentModel.DataAnnotations;

namespace PurchasingCalculator.Shared.Entities;
public class PurchaseItem : BaseEntity
{
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "O preço é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que 0.")]
    public decimal UnitPrice { get; set; }
    [Required(ErrorMessage = "A quantidade é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "A quantidade deve ser maior que 0.")]
    public float Quantity { get; set; } = 1.0f;
    public decimal SubTotal => UnitPrice * ((decimal)Quantity);
}
