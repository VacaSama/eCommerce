using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models;

public class Customer
{
    /// <summary>
    /// 
    /// </summary>
    public int CustomerId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// 
    [StringLength(50, MinimumLength = 8)]

    [DataType(DataType.Password)]
    public required string Password { get; set; }

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
}


/// <summary>
/// A class within a class, brilliant. It is used as a ViewModel for registration.
/// </summary>
public class RegistrationViewModel
{

    public required string FirstName { get; set; }

    public required string LastName { get; set; }


    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }


    [StringLength(50, MinimumLength = 8)]

    [DataType(DataType.Password)]
    public required string Password { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
    [DataType(DataType.Password)]
    public required string ConfirmPassword { get; set; }

    public string? Phone { get; set; }

    public required string StreetAddress { get; set; }

    public required string City { get; set; }

    public required string State { get; set; }
}

/// <summary>
/// LoginViewmodel is another class within a class that is related to Customers class
/// so it will be stored here. Yes, you can do that. It is used as a ViewModel for login.
/// </summary>
public class LoginViewModel
{

    [DataType(DataType.EmailAddress)]
    public required string  Email { get; set;}


    [DataType(DataType.Password)]
    public required string  Password {get; set;} 
}
  
