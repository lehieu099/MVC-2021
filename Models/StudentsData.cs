using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    [Table("StudentsData")]
    public class StudentsData
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Tên Học Sinh")]
        public string Name { get; set; }
        [DisplayName("Dịa Chỉ")]
        public string Address { get; set; }
    }
}