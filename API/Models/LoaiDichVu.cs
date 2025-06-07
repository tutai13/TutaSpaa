using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class LoaiDichVu
    {
        [Key]
        public int LoaiDichVuID { get; set; }

        [Required]
        [StringLength(100)]
        public string TenLoai { get; set; }

        [JsonIgnore]
        public ICollection<DichVu>? DichVus { get; set; }
    }
}
