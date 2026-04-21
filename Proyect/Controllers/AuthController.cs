using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Proyect.Core.DTO;
using Proyect.Core.Models;
using Proyect.Core.Services;
using Proyect.ModelDTO;
using Proyect.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Proyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;
        private readonly IClientService _clientService;


        public AuthController(IClientService clientService,IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            // 1. קבלת המשתמש לפי שם משתמש ואימייל
            //var userByName = await _userService.GetBynameAsync(loginModel.UserName);
            //var userByEmail = await _userService.GetBymailAsync(loginModel.mail);


            var userByName = await _clientService.GetBynameAsync(loginModel.UserName);
            var userByEmail = await _clientService.GetBynameAsync(loginModel.UserName);
            // 2. אם לא נמצא משתמש לפי שם משתמש או אימייל
            if (userByName == null || userByEmail == null)
            {
                return NotFound("שם משתמש או אימייל לא נמצא.");
            }

            // 3. בדיקת סיסמה (אם הסיסמה שגויה, נחזיר Unauthorized)
            if (userByName.mail != loginModel.mail) // שים לב שאתה צריך להשוות לפי אופן שמירת הסיסמה, מומלץ להשתמש בהשוואת hash
            {
                return Unauthorized("סיסמה שגויה.");
            }

            // 4. יצירת רשימת תביעות
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userByName.Name),
                new Claim(ClaimTypes.NameIdentifier, userByEmail.Id.ToString()),
                new Claim(ClaimTypes.Role, "teacher") // או תפקיד אמיתי מהמשתמש
            };

            var key = _configuration["JWT:Key"];

            // 5. אם המפתח לא קיים או קצר מדי
            if (string.IsNullOrEmpty(key) || key.Length < 32)
                throw new Exception("JWT Key must be at least 32 characters long.");

            // 6. יצירת מפתח סודי
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            // 7. יצירת SigningCredentials
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            // 8. יצירת טוקן JWT
            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(60), // הארכתי את תוקף הטוקן ל-60 דקות
                signingCredentials: signinCredentials
            );

            // 9. יצירת המילה המלאה של ה-token
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            // 10. החזרת הטוקן כתגובה
            return Ok(new { Token = tokenString });
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] ClientsPostModel value)
        {
            // 1. בדיקה האם המשתמש כבר קיים
            var existingUser = await _clientService.GetBynameAsync(value.Name);
            if (existingUser != null)
            {
                return BadRequest("שם משתמש או אימייל זה כבר קיימים במערכת.");
            }

            // 2. יצירת האובייקט
            var s = new Clients
            {
                Name = value.Name,
                adress = value.adress,
                mail = value.mail
            };

            // 3. קריאה לשירות (בלי "var result =", כי אין ערך חזרה)
            await _clientService.PostAsync(s);

            // 4. החזרת תשובה חיובית
            return Ok("נרשמת בהצלחה!");
        }
   
    }
}
