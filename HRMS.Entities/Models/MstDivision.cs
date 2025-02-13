﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Entities.Models;

public partial class MstDivision
{
    [Key]
    public int DivisionId { get; set; }
    [Required(ErrorMessage = "Select State.")]
    [DisplayName("State Name")]
    public short StateId { get; set; }
    [Required(ErrorMessage = "Field is required.")]
    [Unicode(false)]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Use letters only")]
    [DisplayName("Division Name (In English)")]
    [StringLength(50)]
    public string DivisionNameEng { get; set; } = null!;
    [Required(ErrorMessage = "कृपया संभाग का नाम दर्ज करें।")]
    [RegularExpression(@"^[\u0900-\u097F\s]+$", ErrorMessage = "संभाग का नाम हिंदी में दर्ज करें।")]
    [DisplayName("संभाग का नाम (हिंदी में)")]
    [StringLength(60)]
    public string? DivisionNameHin { get; set; }
    [Required(ErrorMessage = "Field is required.")]
    [MaxLength(2)]
    [RegularExpression(@"^[0-9]{1,2}$", ErrorMessage = "Must be 2 digits numbers")]
    [Display(Name = "Division Code No.")]
    [StringLength(2)]
    [Unicode(false)]
    public string DivisionCode { get; set; } = null!;

    public bool IsActive { get; set; }
}
