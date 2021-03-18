using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Service;
using Service.Validators;
using System.Collections.Generic;
using Infrastructure.CrossCutting.Models;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    [Authorize]
    public class UserController : BaseController
    {
        private readonly UserService userService;
        public UserController(UserService _userService)
        {
            userService = _userService;
        }

        [Route("Get")]
        [HttpGet]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        public  IActionResult GetUser(int Id)
        {
            try
            {
                return new OkObjectResult(userService.Get(Id));
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        [Route("GetAll")]
        [HttpGet]
        [ProducesResponseType(typeof(IList<User>), StatusCodes.Status200OK)]
        public IActionResult GetAllUser()
        {
            try
            {
                var result = userService.GetAll();
                return new OkObjectResult(result);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        [Route("Post")]
        [HttpPost]
        public IActionResult Post(User user)
        {
            try
            {
                var result = userService.Post(user);
                return new OkObjectResult(result);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        //[Route("Put")]
        //[HttpPut]
        //public UserEntity Put(UserEntity user)
        //{
        //    try
        //    {
        //        return userService.Put<UserValidator>(user);
        //    }
        //    catch (System.Exception)
        //    {

        //        throw;
        //    }
        //}

        //[Route("Delete")]
        //[HttpGet]
        //public void Delete(int Id)
        //{
        //    try
        //    {
        //        userService.Delete(Id);
        //    }
        //    catch (System.Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
