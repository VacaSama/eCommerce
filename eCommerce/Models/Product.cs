using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{

    /// <summary>
    /// This class represents a product for this eCommerce website.
    /// There is sample data within the database that can be uesd to populate and 
    /// simulate a working eCommerce site.
    /// </summary>
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        /// <summary>
        /// This gets and or sets the name of the product. 
        /// This is a required field and must be filled out when creating a new product.
        /// </summary>
        public required string Name { get; set; }
        /// <summary>
        /// This gets and or sets the price of the product. This is a required field and must be filled out when creating a new product. The price is represented as a decimal value to allow for cents and dollars. 
        /// The price should be a positive value and should not exceed a reasonable amount for an eCommerce product.
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// This gets and or sets the category of the product. This is a required field and must be filled 
        /// out when creating a new product. 
        /// The category helps to organize products into different groups, making it easier for customers 
        /// to find what they are looking for. Examples of categories could include "Dairy",
        /// "Merch", etc.
        /// </summary>
        public required string Category { get; set; }
        /// <summary>
        /// This gets and or sets the description of the product. This is an optional field that can be filled out when creating a new product. The description provides additional information about the product, such as its features, benefits, or any other relevant details that may help customers make informed purchasing decisions. The description can be a string of text that gives customers a better 
        /// understanding of what the product is and why they might want to buy it.
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// This gets and or sets the image URL of the product. This is an optional field that can be filled out when creating a new product. The image URL is a string that represents the location of an image file that visually represents the product. This can be a link to an image hosted on a server or a local file path. The image helps customers to see what the product looks like, 
        /// which can enhance their shopping experience and increase the likelihood of making a purchase.
        /// </summary>
        public string? ImageUrl { get; set; }
    }
}
