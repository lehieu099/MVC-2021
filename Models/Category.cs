using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace MvcMovie.Models
{
    [Table("Categories_1")]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [DisplayName("Tên Danh Mục")]
        public string CategoryName { get; set; }
        public ICollection<ProductNew> ProductNew { get; set; }


    }
}