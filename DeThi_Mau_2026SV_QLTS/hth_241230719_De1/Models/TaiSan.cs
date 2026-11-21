using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace hth_241230719_De1.Models;

public partial class TaiSan
{
    public int MaTs { get; set; }
    [Required(ErrorMessage ="Hay chon loai tai san")]
    public int MaLoai { get; set; }
    [Required(ErrorMessage = "Ten tai san khong duoc de trong")]
    public string TenTs { get; set; } = null!;
    [Required(ErrorMessage = "Gia tai san khong duoc de trong")]
    [Range(1, 2000, ErrorMessage ="Nguyen gia phai trong khoan 1-2000")]
    public decimal? NguyenGia { get; set; }
    [Required(ErrorMessage = "Ten file anh khong duoc de trong")]
    [RegularExpression(@"(?i)^.*\.(ipg|jpeg|png|webp)$", ErrorMessage = "tên file\r\nảnh (Anh) phải có đuôi: .jpg | .jpeg | .png | .webp")]
    public string? Anh { get; set; }

    public virtual LoaiTaiSan MaLoaiNavigation { get; set; } = null!;
}
