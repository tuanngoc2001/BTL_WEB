using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_Data;
using System.Security.Cryptography;
using System.Text;
using Web_API_v1.Models;

namespace Web_API_v1.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly ImDbContext _context;

        public UserController(ImDbContext context)
        {
            _context = context;
        }

        // GET: Admin/User
        public async Task<IActionResult> Index()/*(string searchString)*/
        {

            return View();
        }


        // GET: Admin/User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.im_User
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // GET: Admin/User/Create
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,UserName,Password,HoTen,DiaChi,Email,Sdt,Loai,TrangThai")] User userModel)
        {
            if (ModelState.IsValid)
            {

                userModel.Password = StringProcessing.CreateMD5Hash(userModel.Password);
                _context.Add(userModel);
                await _context.SaveChangesAsync();
                var url = Url.RouteUrl("", new { Controller = "Pages", action = "Index", area = "" });
                return Redirect(url);
            }
            return View(userModel);
        }

        //public static string CreateMd5(string input)
        //{
        //    MD5 md5 = System.Security.Cryptography.MD5.Create();
        //    byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        //    byte[] hasBytes = md5.ComputeHash(inputBytes);

        //    StringBuilder sb = new StringBuilder();
        //    for (int i = 0; i < hasBytes.Length; i++)
        //    {
        //        sb.Append(hasBytes[i].ToString("X2"));
        //    }
        //    return sb.ToString();
        //}
       
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.im_User.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }
            return View(userModel);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,UserName,Password,HoTen,DiaChi,Email,Sdt,Loai,TrangThai")] User userModel)
        {
            if (id != userModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModelExists(userModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.im_User
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userModel = await _context.im_User.FindAsync(id);
            _context.im_User.Remove(userModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(int id, ForgotPasswordModel model)
        {
            var user = await _context.im_User.FirstOrDefaultAsync(u => u.ID == id);
            if(user.Password == StringProcessing.CreateMD5Hash(model.Password))
            {                
                if(model.NewPassword == model.NewPasswordConfirm)
                {
                    user.Password = StringProcessing.CreateMD5Hash(model.NewPassword);
                }                
            }
            _context.im_User.Update(user);
            await _context.SaveChangesAsync();
            var url = Url.RouteUrl("", new { Controller = "Login", action = "Index", area = "" });
            return Redirect(url);
        }
        private bool UserModelExists(int id)
        {
            return _context.im_User.Any(e => e.ID == id);
        }
    }
}
