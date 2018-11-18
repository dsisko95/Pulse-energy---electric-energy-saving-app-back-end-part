using BusinessLayer;
using DataLayer.Models;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PulseEnergy.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        private IUserBusiness userBusiness;

        public LoginController(IUserBusiness userBusiness)
        {
            this.userBusiness = userBusiness;
        }

        [Route("{username}/{password}/login")]
        public User GetUserLogin(string username, string password)
        {
            return this.userBusiness.GetUserLogin(username, password);
        }

        [Route("{username}/{secQuestion}/checkUser")]
        public bool GetCheckUser(string username, string secQuestion)
        {
            return this.userBusiness.GetCheckUser(username, secQuestion);
        }

        [Route("updateUserPassword")]
        [HttpPut]
        public bool UpdateOwnerByUsername([FromBody]User user)
        {
            return this.userBusiness.UpdateOwnerPasswordByUsername(user);
        }

    }
}