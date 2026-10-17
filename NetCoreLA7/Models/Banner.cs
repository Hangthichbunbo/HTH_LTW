using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NetCoreLA7.Models
{
    [Table("Banner")]
    [Index(nameof(Name), IsUnique = true)]
    public class Banner
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên banner không được để trống")]
        [StringLength(100, ErrorMessage = "Tên banner tối đa 100 ký tự")]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Tên Banner")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Trạng thái")]
        public byte Status { get; set; } = 1;

        [Display(Name = "Độ ưu tiên")]
        public int Prioty { get; set; } = 0;

        [Required(ErrorMessage = "Hình ảnh banner không được để trống")]
        [StringLength(100)]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Hình ảnh")]
        public string Image { get; set; } = string.Empty;

        [StringLength(350, ErrorMessage = "Mô tả tối đa 350 ký tự")]
        [Column(TypeName = "nvarchar(350)")]
        [Display(Name = "Mô tả")]
        public string? Description { get; set; }
    }
}