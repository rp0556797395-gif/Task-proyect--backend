using Proyect.Core.Repositories;
using Proyect.Core.Services;
using Proyect.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Service
{
    public class TaskServise : ITaskService
    {
        private readonly ITaskReositories _taskRepository;

        public TaskServise(ITaskReositories tasksRepository)
        {
            _taskRepository = tasksRepository;
        }

        public async Task<List<Tasks>> GetAllAsync()
        {
            var x = await _taskRepository.GetAllAsync();
            return x;
        }
        public async Task<Tasks> GetByIdAsync(int id)
        {
            var x = await _taskRepository.GetByIdAsync(id);
            return x;

        }
        public async Task PostAsync(Tasks value)
        {
            await _taskRepository.PostAsync(value);
            await _taskRepository.SaveAsync();

        }
        public async Task PutAsync(int id, Tasks value)
        {
            await _taskRepository.PutAsync(id, value);
            await _taskRepository.SaveAsync();

        }
        public async Task<Tasks> GetBynameAsync(string name)
        {
            return await _taskRepository.GetBynameAsync(name);
        }

        public async Task DeleteAsync(int id)
        {
            await _taskRepository.DeleteAsync(id);
            await _taskRepository.SaveAsync();

        }

    }
}

