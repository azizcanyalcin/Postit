using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Postit.Dtos;
using PostitDataAccessLibrary.DataAccess;
using PostitDataAccessLibrary.Models;

namespace Postit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;
        public UserController(UserContext context) 
        {
            this._context = context;
        }

        [HttpGet]
        public IEnumerable<UserResponseDto> Get()
        {
            var users = _context.User.Where(u => u.DeletedOn == null);

            IList<UserResponseDto> result = new List<UserResponseDto>();

            foreach (var user in users)
            {
                UserResponseDto dto = new UserResponseDto();
                dto.Id = user.Id;
                dto.Name = user.Name;
                dto.Email = user.Email;
                result.Add(dto);
            }
            return result;
        }
        [HttpPost("sign-up")]
        public void SignUp([FromBody] UserDto request) 
        {
            try
            {
                var exist = _context.User.FirstOrDefault(u => u.Email == request.Email);

                if (exist != null)
                    throw new Exception($"{request.Email} zaten kayıtlıdır.");
                    
                User user = new User();
                user.Id = Guid.NewGuid();
                user.Name = request.Name;
                user.Email = request.Email;
                user.Password = request.Password;
                user.Birthday = request.Birthday;
                user.CreatedOn = DateTime.UtcNow;

                _context.User.Add(user);
                
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost("sign-in")]
        public bool SignIn([FromBody] SignInDto request)
        {
            try
            {
                var result = _context.User.FirstOrDefault(u => u.Email == request.Email && u.Password == request.Password);

                if (result == null)
                    return false;
                else
                    return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET api/<testController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPut("{id}/profile")]
        public bool updateProfile(Guid id, [FromBody] UserProfileUpdateDto request)
        {
            var user = _context.User.FirstOrDefault(u => u.Id == id);

            if (user == null) return false;

            user.Name = request.Name;

            _context.SaveChanges();

            return true;

        }
    }
}
