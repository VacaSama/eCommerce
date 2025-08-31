using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models;

/// <summary>
/// This classs is used to represent an item in the shopping cart, 
/// it is a temporary storage for products that a user wants to purchase.
/// </summary>
public class CartItem
{
    [Key] // Primary key for the CartItem is CardId 
    public int CartId { get; set; }

    [Required]  
    public int ProductId { get; set; }
    
    //Product is optional, because the user may or may not have an empty cart. 
    public Product? Product { get; set; }


    [Required]
    public required string Name { get; set; }

    [Required]

    public decimal Price { get; set; }


    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
    public int Quantity { get; set; }

    public string? Category { get; set; }

    // UserId is optional, because the user may or may not be logged in or want to 
    // complete the purchase as a guest. 
    public string? UserId { get; set; }

}

public class CartPreviewViewModel
{
    public required Product Product { get; set; }

    public List<CartItem>? CartItems { get; set; }
}
