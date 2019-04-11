using BigSchool.Models;
using BigShool.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BigSchool.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Địa điểm")]
        public string Place { get; set; }
        [Required]
        [FutureDate(ErrorMessage = "Ngày không hợp lệ, phải lớn hơn ngày hiện tại")]
        [Display(Name = "Ngày")]
        public string Date { get; set; }
        [Required]
        [ValidTime(ErrorMessage = "Giờ không hợp lệ")]
        [Display(Name = "Giờ")]
        public string Time { get; set; }
        [Required]
        [Display(Name = "Danh mục")]
        public byte Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }

        public DateTime GetDateTime()
        {
            return DateTime.Parse(string.Format("{0} {1}", Date, Time));
        }

        public string Heading { get; set; }
        public string Action
        {
            get { return (Id == 0) ? "Tạo mới" : "Lưu lại"; }
        }
    }
}