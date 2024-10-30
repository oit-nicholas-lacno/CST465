using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Contact;

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
    [DisplayName("Email Address")]
    public string Email { get; set; } = "";
}