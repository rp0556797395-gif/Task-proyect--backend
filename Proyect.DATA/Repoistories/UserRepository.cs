using Microsoft.EntityFrameworkCore;
using Proyect.Core.Models;
using Proyect.Core.Repositories;
using Proyect.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Data.Repoistories
{
    public class UserRepository : IUserRepositories
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Clients> GetBymailAsync(string mail)
        {
            var client = await _context.listclient.FirstOrDefaultAsync(s => s.mail == mail);
            if (client == null)
            {
                throw new InvalidOperationException($"No client found with email {mail}");
            }
            return client;
        }

        public async Task<Clients> GetBynameAsync(string name)
        {
            var client = await _context.listclient.FirstOrDefaultAsync(s => s.Name == name);
            if (client == null)
            {
                throw new InvalidOperationException($"No client found with name {name}");
            }
            return client;
        }



    }
}
