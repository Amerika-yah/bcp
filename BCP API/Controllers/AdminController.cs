using BCP_API.Data;
using BCP_API.Entity;
using BCP_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BCP_API.Controllers
{
    public class AdminController : Controller
    {
        private readonly BCPDbContext _dbContext;

        public AdminController(BCPDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Get(int pageIndex = 0, int pageSize = 10)
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                var userCount = _dbContext.Users.Count();
                var userList = _dbContext.Users.Include(x => x.EmpID).Skip(pageIndex * pageSize).Take(pageSize).ToList();

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
                throw;
            }
        }

    }
}
