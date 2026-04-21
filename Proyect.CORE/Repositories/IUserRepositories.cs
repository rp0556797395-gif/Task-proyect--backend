using Proyect.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Core.Repositories
{
    public interface IUserRepositories
    {
        public Task<Clients> GetBymailAsync(string mail);
        public Task<Clients> GetBynameAsync(string name);

    }
}
