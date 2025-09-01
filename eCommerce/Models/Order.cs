using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace eCommerce.Models;

/// <summary>
/// Order class is used to represent a customers order, 
/// it contains information about the order such as the customer id,
/// that we can use to keep track of who placed the order, and store it 
/// in the database. THIS WILL BE IMPLEMENTED LATER - STARTING WITH connection 
/// to the checkout button -- 
/// it will redirect and confirm order, we do not need any payment processing.
/// </summary>
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
