using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public string ProductId { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string ProductName { get; set; }
        [DisplayName("Giá")]
        public decimal UnitPrice { get; set; }
        [DisplayName("Số lượng")]
        public int Quantity { get; set; }
    }
}