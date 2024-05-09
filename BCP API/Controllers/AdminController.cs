using BCP_API.Data;
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
            var userCount = _dbContext.Users.Count();
            var userList = _dbContext.Users.Include(x => x.EmpID).Skip(pageIndex * pageSize).Take(pageSize).ToList();

            return View();
        }

    }
}
