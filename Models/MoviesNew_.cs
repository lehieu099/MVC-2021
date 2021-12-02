using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    [Table("MoviesNew_")]
    public class MoviesNew_
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Tên Phim")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Ngày Chiếu")]
        public DateTime ReleaseDate { get; set; }
        [DisplayName("Thể Loại")]
        public string Genre { get; set; }
        [DisplayName("Giá")]
        public decimal Price { get; set; }
        public string Rating { get; set; }
    }
}