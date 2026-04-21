using Proyect.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Core.Services
{
    public interface IUserService
    {

        public Task<Clients> GetBymailAsync(string mail);

        //public Clients adduserAsync(Clients value);

        public Task<Clients> GetBynameAsync(string name);



    }
}
