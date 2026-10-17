using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NetCoreLA7.Models
{
    [Table("Product")]
    [Index(nameof(Name), IsUnique = true)]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(100, ErrorMessage = "Tên sản phẩm tối đa 100 ký tự")]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá phải lớn hơn hoặc bằng 0")]
        [Display(Name = "Giá gốc")]
        public double Price { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Giá khuyến mãi phải >= 0")]
        [Display(Name = "Giá khuyến mãi")]
        public double SalePrice { get; set; } = 0;

        [Display(Name = "Trạng thái")]
        public byte Status { get; set; } = 1;

        [Required(ErrorMessage = "Vui lòng chọn danh mục")]
        [Display(Name = "Danh mục")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

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
    }
}