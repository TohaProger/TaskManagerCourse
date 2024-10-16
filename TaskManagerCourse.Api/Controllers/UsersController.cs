using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using TaskManagerCourse.Api.Data;
using TaskManagerCourse.Api.Models;
using TaskManagerCourse.Common.Models;

namespace TaskManagerCourse.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _db;

        public UsersController(MyDbContext db)
        {
            _db = db;
        }

        [HttpGet("test")]
        public IActionResult TestApi()
        {
            return Ok("Всем привет! Я живое!!!");
        }

        [HttpPost("create")]
        public IActionResult CreateUser([FromBody] UserModel userModel)
        {
            if (userModel != null)
            {
                User newUser = new User(userModel.FirstName, userModel.LastName, userModel.Email,
                    userModel.Password, userModel.Phone, userModel.Status, userModel.Photo);
                _db.Users.Add(newUser);
                _db.SaveChanges();
                return Ok($"новый user - {userModel.FirstName} создан");
            }
            return BadRequest();
        }

        [HttpPatch("update/{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserModel userModel)
        {
            if (userModel != null)
            {
                User? userForUpdate = _db.Users.FirstOrDefault(u => u.Id == id);
                if (userForUpdate != null) {
                    userForUpdate.FirstName = userModel.FirstName;
                    userForUpdate.LastName = userModel.LastName;
                    userForUpdate.Email = userModel.Email;
                    userForUpdate.Password = userModel.Password;
                    userForUpdate.Phone = userModel.Phone;
                    userForUpdate.Status = userModel.Status;
                    userForUpdate.Photo = userModel.Photo;

                    _db.Users.Update(userForUpdate);
                    _db.SaveChanges();
                    return Ok($"user {userForUpdate.LastName} обновлен");
                }
                return NotFound();
            }
            return BadRequest();
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            User? userForDelete = _db.Users.FirstOrDefault(u => u.Id == id);
            if (userForDelete != null)
            {
                _db.Users.Remove(userForDelete);
                _db.SaveChanges();
                return Ok($"user {userForDelete.FirstName} удален");
            }
            return NotFound();
        }

        // вызов асинхронного метода получения списка всех пользователей
        [HttpGet]
        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            return await _db.Users.Select(u => u.ToDto()).ToListAsync();
        }

        [HttpPost("create/all")]
        public async Task<IActionResult> CreateMultipleUsers([FromBody] List<UserModel> userModels)
        {
            if (userModels != null && userModels.Count > 0)
            {
                var newUsers = userModels.Select(u => new User(u));
                _db.Users.AddRange(newUsers);
                await _db.SaveChangesAsync();
                return Ok(newUsers);
            }
            return BadRequest();
        }

        /*Вариант обычного получения списка всех пользователей
        [HttpGet]
        public IEnumerable<UserModel> GetUsers()
        {
            return _db.Users.Select(u => u.ToDto());
        }*/
    }
}
