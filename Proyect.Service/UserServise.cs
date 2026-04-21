using Proyect.Core.Models;
using Proyect.Core.Repositories;
using Proyect.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Service
{
    public class UserServise : IUserService
    {
        private readonly IUserRepositories _userRepositories;

        public UserServise(IUserRepositories _userService)
        {
            _userRepositories = _userRepositories;
        }


        public async Task<Clients> GetBymailAsync(string mail)
        {

            var x = await _userRepositories.GetBymailAsync(mail);
            return x;
        }
        public async Task<Clients> GetBynameAsync(string name)
        {
            if (_userRepositories == null)
            {
                throw new InvalidOperationException("UserService was not initialized.");
            }
            if (string.IsNullOrEmpty(name))
            {
                // טיפול במקרים של שם ריק או null
                throw new ArgumentException("Name cannot be null or empty", nameof(name));
            }

            var x = await _userRepositories.GetBymailAsync(name);

            // אם _userService.GetBymailAsync מחזיר null, יכול להיות שתרצה להחזיר ערך ברירת מחדל או טיפול בשגיאה
            if (x == null)
            {
                // אם יש צורך, אפשר להחזיר null או להרים Exception אחר
                return null;  // או throwing an exception
            }

            return x;
        }




    }
}
