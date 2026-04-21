using Proyect.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Core.Services
{
    public interface IClientService
    {
        public Task<List<Clients>> GetAllAsync();
        public Task<Clients> GetByIdAsync(int id);
        public Task<Clients> GetBynameAsync(string name);
        public Task<Clients> GetBymailAsync(string mail);
        
        public Task PostAsync(Clients value);
        public Task PutAsync(int id, Clients value);
        public Task DeleteAsync(int id);
    }
}
