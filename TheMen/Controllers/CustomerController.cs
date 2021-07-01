using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheMen.Models;

namespace TheMen.Controllers
{
    public class CustomerController : Controller
    {
        TheMenDbContext context = new TheMenDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        //hàm Registration(post) nhận dl từ trang Registration và thực hiện tạo mới dl
        [HttpPost]
        public ActionResult Registration(FormCollection collection, Customer cus)
        {
            //gán các giá trị người dùng nhập
            var name = collection["Name"];
            var account = collection["Account"];
            var pass = collection["Pass"];
            var nhaplaipass = collection["NhapLaiPass"];
            var email = collection["Email"];
            var phone = collection["Phone"];
            var ngaysinh = String.Format("0:MM/dd/yyyy", collection["Ngaysinh"]);
            if (String.IsNullOrEmpty(name))
            {
                ViewData["Loi1"] = "Họ tên không được để trống nho";
            }
            else if (String.IsNullOrEmpty(account))
            {
                ViewData["Loi2"] = "Tên đăng nhập không được để trống nho";
            }
            else if (String.IsNullOrEmpty(pass))
            {
                ViewData["Loi3"] = "Mật khẩu không được để trống nho";
            }
            else if (String.IsNullOrEmpty(nhaplaipass))
            {
                ViewData["Loi4"] = "Phải nhập lại mật khẩu nho";
            }
            if (String.IsNullOrEmpty(email))
            {
                ViewData["Loi5"] = "Email không được để trống nho";
            }
            if (String.IsNullOrEmpty(phone))
            {
                ViewData["Loi6"] = "Số điện thoại không được để trống nho";
            }
            else
            {
                //gán giá trị cho đối tượng đc tạo mới (cus)
                cus.Name = name;
                cus.Account = account;
                cus.Pass = pass;
                cus.Email = email;
                cus.Phone = phone;
                cus.Ngaysinh = DateTime.Parse(ngaysinh);
                context.Customer.InsertOnSubmit(cus);
                context.SubmitChanges();
                return RedirectToAction("Login");
            }
            return this.Registration();
        }
    }
}