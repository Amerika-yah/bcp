using BCP_API.Data;
using BCP_API.Entity;
using BCP_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

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
        public IActionResult Post(AddUserViewModel model)
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                if (ModelState.IsValid)
                {
                    var postedModel = new Users()
                    {
                        EmpID = model.EmpID,
                        Password = "FirstActivation",
                        Firstname = model.Firstname,
                        Lastname = model.Lastname,
                        Email = model.Email,
                        Department = model.Department,
                        Project = model.Project,
                        Group = model.Group,
                        Role = model.Role
                    };
                    _dbContext.Users.Add(postedModel);
                    _dbContext.SaveChanges();


                    response.Status = false;
                    response.Message = "Saved successfully.";
                    response.Data = postedModel;

                    return Ok(response);
                }
                else 
                {
                    response.Status = false;
                    response.Message = "Validation Failed.";
                    response.Data = ModelState;   
                    return BadRequest(response); 
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
