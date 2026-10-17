using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DhlLesson09Bai2TuLam.Models
{
    [Table("BANNER")]
    public class DhlBanner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Mã banner")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên banner không được để trống")]
        [StringLength(100, ErrorMessage = "Tên banner tối đa 100 ký tự")]
        [Display(Name = "Tên banner")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Trạng thái")]
        public byte Status { get; set; } = 1;

        [Display(Name = "Độ ưu tiên (Prioty)")]
        public int Prioty { get; set; } = 0;

        [StringLength(100, ErrorMessage = "Tên/đường dẫn ảnh tối đa 100 ký tự")]
        [Display(Name = "Hình ảnh")]
        [Column(TypeName = "varchar(100)")]
        public string? Image { get; set; }

        [StringLength(350, ErrorMessage = "Mô tả tối đa 350 ký tự")]
        [Display(Name = "Mô tả")]
        public string? Description { get; set; }
    }
}
