using Proyect.Core.Repositories;
using Proyect.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Proyect.Data.Repoistories
{
    public class ClientRepository: IClientRepositories
    {
        private readonly DataContext _context;

        public ClientRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Clients>> GetAllAsync()
        {
            return await _context.listclient.ToListAsync();
        }
        public async Task<Clients> GetByIdAsync(int id)
        {
            return await _context.listclient.FirstAsync(s => s.Id == id);
        }

        public async Task<Clients> GetBynameAsync(string name)
        {
            var x = await _context.listclient.FirstOrDefaultAsync(s => s.Name == name);

            // אם אין לקוח עם השם המבוקש, מחזיר null או טיפול במצב זה
            if (x == null)
            {
                 return null;

            } 
            return x; 
        }
        public async Task<Clients> GetBymailAsync(string mail)
        {
            var x = await _context.listclient.FirstOrDefaultAsync(s => s.mail == mail);

            // אם אין לקוח עם השם המבוקש, מחזיר null או טיפול במצב זה
            if (x == null)
            {
                 return null;

            } 
            return x; 
        }
        public async Task PostAsync(Clients value)
        {
            var c =await _context.listclient.FirstOrDefaultAsync(s => s.Id == value.Id);
            if (c == null)
            {
                 await _context.listclient.AddAsync(value);
            }
            else
            {
                // אם הלקוח קיים כבר, ניתן להוסיף לוגיקה אחרת אם צריך
                throw new Exception("הלקוח כבר קיים.");
            }

        }
 

        public async Task PutAsync(int id, Clients value)
        {
            var c =await _context.listclient.FirstAsync(s => s.Id == id);
            c.Name = value.Name;
            c.adress = value.adress;
            c.mail = value.mail;

        }
        public async Task DeleteAsync(int id)
        {
            // 1. חיפוש הלקוח לפי ה-ID
            var client = await _context.listclient.FirstOrDefaultAsync(s => s.Id == id);
            _context.listclient.Remove(client);
            await _context.SaveChangesAsync();
            
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }


    }
}
