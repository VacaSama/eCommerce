using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace eCommerce.Models;

public class Order
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }

    public decimal ShippingAmount { get; set; }
    public int TaxAmount { get; set; } = 25;

    public decimal SubtotalAmount { get; set; }
    public decimal TotalAmount { get; set; }

}
