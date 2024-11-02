using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

public class ContactFormModel
{
    [Required]
    [DisplayName("First Name")]
    [StringLength(20)]
    public string FirstName { get; set; } = "";

    [Required]
    [DisplayName("Last Name")]
    [StringLength(40)]
    public string LastName { get; set; } = "";

    [Required]
    [DisplayName("Address")]
    public string Address { get; set; } = "";

    [Required]
    [DisplayName("City")]
    public string City { get; set; } = "";

    [Required]
    [DisplayName("State")]
    public string State { get; set; } = "";

    [Required]
    [DisplayName("Zip Code")]
    public string ZipCode { get; set; } = "";
}