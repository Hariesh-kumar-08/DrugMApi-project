using DrugMApi.Models;
using DrugMApi.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DrugMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginRepo obj;

        public LoginController()
        {
            obj = new LoginRepo(new mdContext());
        }


        [HttpPost]
        public User Login(User users)
        {
            var result = obj.Logins(users);
            obj.Save();
            return result;

        }
        [HttpPost("{AdminLogin}")]
        public Admin AdminLogin(Admin admin)
        {
            var result = obj.AdminLogin(admin);
           return result;
        }
        [HttpGet]
        public List<User> UserList()
        {
            List<User> u = obj.UserList();
            return u;
        }
    }
}
