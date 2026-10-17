using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NetCoreLA7.Models
{
    [Table("Category")]
    [Index(nameof(Name), IsUnique = true)]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(100, ErrorMessage = "Tên danh mục tối đa 100 ký tự")]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Trạng thái")]
        public byte Status { get; set; } = 1;

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [Display(Name = "Ngày tạo")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [StringLength(100)]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Hình ảnh")]
        public string? Image { get; set; }

        [StringLength(350, ErrorMessage = "Mô tả tối đa 350 ký tự")]
        [Column(TypeName = "nvarchar(350)")]
        [Display(Name = "Mô tả")]
        public string? Description { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}