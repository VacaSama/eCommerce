namespace eCommerce.Models;

/// <summary>
/// This classs is used to represent an item in the shopping cart, 
/// it is a temporary storage for products that a user wants to purchase.
/// </summary>
public class CartItem
{
    public int CartId { get; set; }
    public int ProductId { get; set; }
    
    //Product is optional, because the user may or may not have an empty cart. 
    public Product? Product { get; set; }
    public int Quantity { get; set; }

    // UserId is optional, because the user may or may not be logged in or want to 
    // complete the purchase as a guest. 
    public string? UserId { get; set; }



}
