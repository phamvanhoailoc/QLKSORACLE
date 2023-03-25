using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebQLKSORACLE.Models;

namespace WebQLKSORACLE.Areas.ADMIN.ModelViews
{
    public class RegisterAdminVM
    {
        [Key]
        public int MaNv { get; set; }
        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        public string TenNv { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        [MaxLength(150)]
        [DataType(DataType.EmailAddress)]
        [Remote(action: "ValidateEmail", controller: "Accounts")]
        public string EmailNv { get; set; }
       
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Display(Name = "Điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [Remote(action: "ValidatePhone", controller: "Accounts")]
        public decimal SdtNv { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [MinLength(5, ErrorMessage = "Bạn cần đặt mật khẩu tối thiểu 5 ký tự")]
        public string MatkhauNv { get; set; }
        [MinLength(5, ErrorMessage = "Bạn cần đặt mật khẩu tối thiểu 5 ký tự")]
        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("MatkhauNv", ErrorMessage = "Vui lòng nhập mật khẩu giống nhau")]
        public string ConfirmMatkhauNv { get; set; }
        public string DiachiNv { get; set; }
        public bool GioitinhNv { get; set; }
        public decimal RoleId { get; set; }
        public bool TrangthaiNv { get; set; }
        public virtual RoLe Role { get; set; }
    }
}
