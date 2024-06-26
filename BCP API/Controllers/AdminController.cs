﻿using BCP_API.Data;
using BCP_API.Entity;
using BCP_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace BCP_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly BCPDbContext _dbContext;

        public AdminController(BCPDbContext dbContext)
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
        public IActionResult Get(int pageIndex = 0, int pageSize = 10)
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                var userCount = _dbContext.Users.Count();
                var userList = _dbContext.Users.Skip(pageIndex * pageSize).Take(pageSize).ToList();

                response.Status = true;
                response.Message = "Success";
                response.Data = new { Users = userList, Count = userCount };

                //return View();
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error getting Users: " + ex.Message;
                Console.WriteLine(response.Message);
                //throw;
                return BadRequest(response);
            }
        }


        [HttpPost]
        public IActionResult AddUser(AddUserViewModel model)
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                if (ModelState.IsValid)
                {
                    var users = _dbContext.Users.Where(x => model.EmpID.ToString().Contains(x.EmpID.ToString())).ToList();

                    if (users.Count > 0)
                    {
                        response.Status = false;
                        response.Message = "Users Not Found.";
                        return BadRequest(response);
                    }

                    var postedModel = new Users()
                    {
                        EmpID = model.EmpID,
                        Password = GetMD5("FirstActivation"),
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
                response.Message = "Error adding Users: " + ex.Message;
                Console.WriteLine(response.Message);

                return BadRequest(response);
            }
        }


        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                var user = _dbContext.Users.Where(x => x.EmpID == id).FirstOrDefault();

                if(user == null)
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
                response.Message = "Error get User by Id: " + ex.Message;
                Console.WriteLine(response.Message);

                return BadRequest(response);
            }
        }


        [HttpPut]
        public IActionResult UpdateUser(AddUserViewModel model)
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                if (ModelState.IsValid)
                {
                    var user = _dbContext.Users.Where(x => x.EmpID == model.EmpID).FirstOrDefault();
                    if (user != null)
                    {
                        user.EmpID = model.EmpID;
                        user.Password = GetMD5(model.Password);
                        user.Firstname = model.Firstname;
                        user.Lastname = model.Lastname;
                        user.Email = model.Email;
                        user.Department = model.Department;
                        user.Project = model.Project;
                        user.Group = model.Group;
                        user.Role = model.Role;

                        _dbContext.SaveChanges();

                        response.Status = false;
                        response.Message = "Saved successfully.";
                        response.Data = model;

                        return Ok(response);
                    }
                    else
                    {
                        response.Status = false;
                        response.Message = "Update Failed.";
                        response.Data = ModelState;
                        return BadRequest(response);
                    }


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
                response.Message = "Error updating User: " + ex.Message;
                Console.WriteLine(response.Message);

                return BadRequest(response);
            }
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            BaseResponseModel response = new BaseResponseModel();
            try
            {
                var movie = _dbContext.Users.Where(x => x.EmpID == id).FirstOrDefault();

                if (movie == null)
                {
                    response.Status = false;
                    response.Message = "Invalid Movie Record.";

                    return BadRequest(response);
                }

                _dbContext.Users.Remove(movie);
                _dbContext.SaveChanges();

                response.Status = true;
                response.Message = "Deleted Successfully";

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "Error deleting User: " + ex.Message;

                return BadRequest(response);
            }
        }


    }
}
