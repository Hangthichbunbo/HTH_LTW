using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hoangthuhang_241230719.Models;

public partial class Sach
{
    public int MaSach { get; set; }
    [Display(Name = "MaTl")]
    public int MaTl { get; set; }
    [Required(ErrorMessage ="Ten sach khong duoc de trong")]
    [Display(Name ="TenSach")]
    public string TenSach { get; set; } = null!;
    [Required(ErrorMessage = "Gia khong duoc de trong")]
    [Range(50,1000, ErrorMessage = "Gia phải là số và nằm trong giới hạn từ 50 đến 1000")]
    [Display(Name ="Gia")]
    public decimal? Gia { get; set; }
    [RegularExpression(@"(?i)^.*\.(jpg|ipeg|png|webp)$", ErrorMessage = "Tên file ảnh phải có đuôi: .jpg | .jpeg | .png | .webp")]
    [Display(Name = "Anh")]
    public string? Anh { get; set; }

    public virtual TheLoai MaTlNavigation { get; set; } = null!;
}
