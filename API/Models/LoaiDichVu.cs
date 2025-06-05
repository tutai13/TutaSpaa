using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class LoaiDichVu
    {
        [Key]
        public int LoaiDichVuID { get; set; }

        [Required]
        [StringLength(100)]
        public string TenLoai { get; set; }

        // Navigation property: Một loại dịch vụ có nhiều dịch vụ
        public ICollection<DichVu>? DichVus { get; set; }
    }
}
