using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCoreMVCLAB5.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [MinLength(6, ErrorMessage = "Tên sản phẩm ít nhất 6 ký tự")]
        [MaxLength(150, ErrorMessage = "Tên sản phẩm tối đa 150 ký tự")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Ảnh sản phẩm phải được chọn")]
        [Display(Name = "Ảnh sản phẩm")]
        public string? Image { get; set; }
        [NotMapped] // Không lưu vào database
        public IFormFile? ImageFile { get; set; }

        [Required(ErrorMessage = "Giá sản phẩm không được để trống")]
        [Range(100000, double.MaxValue, ErrorMessage = "Giá sản phẩm phải lớn hơn hoặc bằng 100000")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Giá khuyến mãi không được để trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá khuyến mãi không được âm")]
        public float SalePrice { get; set; }

        [Required(ErrorMessage = "Mô tả không được để trống")]
        [MaxLength(1500, ErrorMessage = "Mô tả không vượt quá 1500 ký tự")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Danh mục không được để trống")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // 1. SalePrice phải nhỏ hơn Price ít nhất 10%
            if (SalePrice >= Price * 0.9)
            {
                yield return new ValidationResult(
                    "Giá khuyến mãi phải nhỏ hơn giá chuẩn ít nhất 10%",
                    new[] { nameof(SalePrice) });
            }

            // 2. Description không chứa từ nhạy cảm
            string[] badWords = { "die", "admin", "fack" };
            if (!string.IsNullOrEmpty(Description))
            {
                foreach (var word in badWords)
                {
                    if (Description.Contains(word, StringComparison.OrdinalIgnoreCase))
                    {
                        yield return new ValidationResult(
                            $"Mô tả chứa từ nhạy cảm: {word}",
                            new[] { nameof(Description) });
                    }
                }
            }
        }

    }
}
