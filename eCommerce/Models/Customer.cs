using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models;

public class Customer
{
    /// <summary>
    /// 
    /// </summary>
    public int CustomerId { get; set; }

    // Customer Personal Information BELOW
    /// <summary>
    /// 
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required string LastName { get; set; }

    // Customer Billing Information BELOW
    /// <summary>
    /// 
    /// </summary>
    public string? Phone { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public required string StreetAddress { get; set; } 

    /// <summary>
    /// 
    /// </summary>

    public required string City { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required string State { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required string ZipCode { get; set; }
}



