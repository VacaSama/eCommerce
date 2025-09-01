namespace eCommerce.Models;


/// <summary>
/// This class works in conjunction with the Order class to represent an OrderSummary 
/// for a specific order/customer. It can be viewed in the Order History Page, which 
/// has not been implemented or planned at this time. 
/// </summary>
public class OrderDetail
{
    public int OrderDetailId { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
