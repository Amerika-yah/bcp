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

        [HttpGet]
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
                //throw;
                return BadRequest(response);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                var user = _dbContext.Users.Include(x => x.EmpID).Where(x => x.id == id).FirstOrDefault();

                if(user != null)
                {
                    response.Status = false;
                    response.Message = "User Not Found.";

                    return BadRequest(response);
                }

                response.Status = true;
                response.Message = "Success";
                response.Data = user;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                Console.WriteLine(response.Message);

                return BadRequest(response);
            }
        }

        [HttpPost]
        public IActionResult Post()
        {

            return View();
        }







    }
}
