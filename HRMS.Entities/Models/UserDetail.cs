using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Entities.Models;

public partial class UserDetail
{
    [Key]
    public int UserId { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Roles { get; set; } = null!;
}
