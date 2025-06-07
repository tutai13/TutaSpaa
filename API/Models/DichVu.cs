using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace API.Models
{
    public class DichVu
    {
        [Key]
        public int DichVuID { get; set; }

        [Required]
        [StringLength(100)]
        public string TenDichVu { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Gia { get; set; }

        [Required]
        public int ThoiGian { get; set; } // phút

        [StringLength(500)]
        public string? MoTa { get; set; }

        [StringLength(255)]
        public string HinhAnh { get; set; }

        [Required]
        public int TrangThai { get; set; }

        [Required]
        public DateTime NgayTao { get; set; } = DateTime.Now;

        // ✅ Khóa ngoại rõ ràng
        [Required]
        public int LoaiDichVuID { get; set; }

        [ForeignKey("LoaiDichVuID")]
        [JsonIgnore]
        public LoaiDichVu? LoaiDichVu { get; set; }
    }

}
