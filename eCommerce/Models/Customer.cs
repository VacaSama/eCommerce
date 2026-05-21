using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models;

public class Customer
{
    /// <summary>
    /// Unique Identifier for the Customer Model 
    /// </summary>
    public int CustomerId { get; set; }

    // Link to IdentityUser BELOW
    public string? IdentityUserId { get; set; }
    public IdentityUser? IdentityUser { get; set; }

    // Customer Personal Information BELOW
    /// <summary>
    /// Gets or sets the first name of the customer. This is a required field and cannot be null or empty.
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the customer. This is a required field and cannot be null or empty.
    /// </summary>
    public required string LastName { get; set; }

    // Customer Billing Information BELOW
    /// <summary>
    /// Gets or sets the phone number of the customer. This is an optional field and must be a valid email format.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Gets or sets the Street Address of the customer. This is a required field and cannot be null or empty.
    /// </summary>
    public required string StreetAddress { get; set; }

    /// <summary>
    /// Gets or sets the city of the customer. This is a required field and cannot be null or empty.
    /// </summary>
    public required string City { get; set; }

    /// <summary>
    /// Gets or sets the state of the customer. This is a required field and cannot be null or empty.
    /// </summary>
    public required string State { get; set; }

    /// <summary>
    /// Gets or sets the zip code of the customer. This is a required field and cannot be null or empty.
    /// </summary>
    public required string ZipCode { get; set; }
}



