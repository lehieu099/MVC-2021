using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace MvcMovie.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public string EmployeeID { get; set; }
        [DisplayName("Tên")]
        public string EmployeeName { get; set; }
        [DisplayName("Số điện thoại")]
        public int PhoneNumber { get; set; }
    }
}