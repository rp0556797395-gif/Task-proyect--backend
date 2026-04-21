using Proyect.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Core.Repositories
{
    public interface ITaskReositories
    {
        public Task<List<Tasks> >GetAllAsync();
        public Task<Tasks> GetByIdAsync(int id);
        public Task PostAsync(Tasks value);
        public Task<Tasks> GetBynameAsync(string name);

        public Task PutAsync(int id, Tasks value);
        public Task DeleteAsync(int id);
        public Task SaveAsync();
    }
}
