namespace API.DTOs.Product
{
    public class ProductDTO
    {
        public int SanPhamId { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public string MoTa { get; set; }
        public decimal Gia { get; set; }
        public string HinhAnh { get; set; }
        public int LoaiSanPhamId { get; set; }

    }
}
