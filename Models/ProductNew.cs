using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models{
    [Table("ProductNew_")]
    public class ProductNew{
        [Key]
        public int ProductNewID {get; set;}
        [DisplayName("Tên Sản Phẩm")]
        public string ProductNewName{get; set;}
        [DisplayName("Danh Mục")]

        public int CategoryID {get;set;}
        [DisplayName("Danh Mục")]

        public Category Categories_ {get; set;}
    }
}