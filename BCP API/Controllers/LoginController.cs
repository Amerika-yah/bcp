using Azure;
using BCP_API.Data;
using BCP_API.Entity;
using BCP_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace BCP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly BCPDbContext _dbContext;

        public LoginController(BCPDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [NonAction]
        public static string GetMD5(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(text);
            byte[] targetData = md5.ComputeHash(fromData);
            string byteToString = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byteToString += targetData[i].ToString("x2");
            }

            return byteToString;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                var userCount = _dbContext.Users.Count();
                var userList = _dbContext.Users.ToList();

                response.Status = true;
                response.Message = "Success";
                response.Data = new { Users = userList, Count = userCount };

                //return View();
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                Console.WriteLine(response.Message);
                //throw;
                return BadRequest(response);
            }
        }

        [HttpPost("{email}/{password}")]
        public IActionResult Login(string email, string password)
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                var encryptedPassword = GetMD5(password);
                var data = _dbContext.Users.Where(u => u.Email.Equals(email) && u.Password.Equals(encryptedPassword)).ToList();

                if (data.IsNullOrEmpty())
                {
                    response.Status = false;
                    response.Message = "User Not Found.";

                    return BadRequest(response);
                }
                else
                {
                    response.Status = true;
                    response.Message = "Success";
                    response.Data = data;

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                Console.WriteLine(response.Message);

                return BadRequest(response);
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }

        // TODO: Forgot Password
        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                var encryptedOldPassword = GetMD5(model.OldPassword);
                var encryptedNewPassword = GetMD5(model.NewPassword);

                var result = _dbContext.Users.SingleOrDefault(u => u.EmpID.Equals(model.EmpID) && u.Password.Equals(encryptedOldPassword));

                if (result == null)
                {
                    response.Status = false;
                    response.Message = "User Not Found.";

                    return BadRequest(response);
                }
                else
                {
                    result.Password = encryptedNewPassword;
                    _dbContext.SaveChanges();

                    response.Status = true;
                    response.Message = "Success";
                    response.Data = result;

                    return Ok(response);
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                Console.WriteLine(response.Message);

                return BadRequest(response);
            }
        }

        
    }
}
