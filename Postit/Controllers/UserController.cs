using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Postit.Dtos;
using PostitDataAccessLibrary.DataAccess;
using PostitDataAccessLibrary.Models;
using QRCoder;
using System.Drawing.Printing;
using static QRCoder.PayloadGenerator;

namespace Postit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _userContext;
        private readonly DataContext _noteContext;
        public UserController(DataContext UserContext, DataContext NoteContext) 
        {
            this._userContext = UserContext;
            this._noteContext = NoteContext;
        }
        

        [HttpGet]
        public IEnumerable<UserResponseDto> Get()
        {
            
            var users = _userContext.User.Where(u => u.DeletedOn == null);

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
        public void SignUp([FromBody] SingUpDto request) 
        {
            try
            {
                var exist = _userContext.User.FirstOrDefault(u => u.Email == request.Email);

                if (exist != null)
                    throw new Exception($"{request.Email} zaten kayıtlıdır.");
                    
                User user = new User();
                user.Id = Guid.NewGuid();
                user.Name = request.Name;
                user.Email = request.Email;
                user.Password = request.Password;
                user.Birthday = request.Birthday;
                user.CreatedOn = DateTime.UtcNow;

                _userContext.User.Add(user);

                _userContext.SaveChanges();
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
                var result = _userContext.User.FirstOrDefault(u => u.Email == request.Email && u.Password == request.Password);

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
            var user = _userContext.User.FirstOrDefault(u => u.Id == id);

            if (user == null) return false;

            user.Name = request.Name;

            _userContext.SaveChanges();

            return true;

        }

        [HttpPost("notes/add-note")]
        public bool AddNote([FromBody] NoteAddDto request, string email)
        {
            var user = _userContext.User.FirstOrDefault(u => u.Email == email);

            Note note = new Note();

            note.Name = request.Name;
            note.Description = request.Description;
            note.CreatedOn = DateTime.UtcNow;
            note.Id = Guid.NewGuid();
            note.CreatedById = user.Id;

            try
            {
                if (request == null)
                    return false;
                else
                {
                    
                    _noteContext.Note.Add(note);
                    _noteContext.SaveChanges();
                }
                
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("notes/get-notes")]
        public IEnumerable<Note> GetNote(string email)
        {   
            var user = _userContext.User.FirstOrDefault(u => u.Email == email);
            return _noteContext.Note.Where(u => u.CreatedById == user.Id ); 
        }
        [HttpPost("qrCode")]
        public string qrGenerator(string email)
        {
            var user = _userContext.User.FirstOrDefault(u => u.Email == email);
            

            Url generator = new Url($"https://postit.com/{email}");
            string payload = generator.ToString();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
            AsciiQRCode qrCode = new AsciiQRCode(qrCodeData);
            string qrCodeAsAsciiArt = qrCode.GetGraphic(1);

            return qrCodeAsAsciiArt;
        }
    }
}
