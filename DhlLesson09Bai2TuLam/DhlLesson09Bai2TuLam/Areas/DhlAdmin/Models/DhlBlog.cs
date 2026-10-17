using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DhlLesson09Bai2TuLam.Areas.DhlAdmin.Models
{
    [Table("BLOG")]
    public class DhlBlog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Mã bài viết")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên bài viết không được để trống")]
        [StringLength(100, ErrorMessage = "Tên bài viết tối đa 100 ký tự")]
        [Display(Name = "Tên bài viết")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Trạng thái")]
        public byte Status { get; set; } = 1;

        [Display(Name = "Ngày tạo")]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; } = DateTime.Now.Date;

        [StringLength(100, ErrorMessage = "Tên/đường dẫn ảnh tối đa 100 ký tự")]
        [Display(Name = "Hình ảnh")]
        [Column(TypeName = "varchar(100)")]
        public string? Image { get; set; }

        [StringLength(350, ErrorMessage = "Mô tả tối đa 350 ký tự")]
        [Display(Name = "Mô tả")]
        public string? Description { get; set; }
    }
}
