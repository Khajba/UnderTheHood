using Microsoft.AspNetCore.Mvc;
using Uth.Backend.Api.Models;
using Uth.Repository.Abstract;

namespace Uth.Backend.Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public ResponseMessage Register(RegisterUserModel model)
        {
            _userRepository.Register(model.Email, model.Firstname, model.Lastname, model.Password);

            return new ResponseMessage
            {
                IsSuccess = true
            };
        }
    };
}
