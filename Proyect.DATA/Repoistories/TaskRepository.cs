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
    public class TaskRepository: ITaskReositories
    {
        private readonly DataContext _context;

        public TaskRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<List<Tasks>> GetAllAsync()
        {
            return await _context.listtask.ToListAsync();
        }

        public async Task<Tasks> GetByIdAsync(int code)
        {
            return await _context.listtask.FirstAsync(s => s.Code == code);
           
        }
        // בערך בשורה 43
      

        public async Task PostAsync( Tasks value)
        {
            var t =await _context.listtask.FirstOrDefaultAsync(s => s.Code == value.Code);
            if (t == null)
            {
               await _context.listtask.AddAsync(value);
            }
        }
        public async Task<Tasks> GetBynameAsync(string name)
        {
            return await _context.listtask.FirstOrDefaultAsync(s => s.Name == name);
        }
     
        public async Task PutAsync(int code,  Tasks value)
        {
            var t =await _context.listtask.FirstAsync(s => s.Code == code);
            t.Name = value.Name;
            t.IsCompleted = value.IsCompleted;
            t.Category = value.Category;
         

        }
        public async Task DeleteAsync(int code)
        {
            // 1. מחפשים את הישות
            var t = await _context.listtask.FirstOrDefaultAsync(s => s.Code == code);

            // 2. בדיקה קריטית: רק אם מצאנו, נמחק
            if (t != null)
            {
                _context.listtask.Remove(t);
                await _context.SaveChangesAsync();
            }
            // אם t הוא null, הפונקציה פשוט תסתיים בלי לקרוס
        }
        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }


    }
}
