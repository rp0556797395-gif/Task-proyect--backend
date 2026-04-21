using Microsoft.AspNetCore.Mvc;
using Proyect.Core.Services;
using Proyect.Core;
using System.Collections.Generic;
using Proyect.Core.Models;
using AutoMapper;
using Proyect.Core.DTO;
using Proyect.Service;
using Proyect.ModelDTO;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;





// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _Taskervice;
        private readonly IMapper _mapper;

        public TasksController(ITaskService context, IMapper mapper)
        {
            _Taskervice = context;
            _mapper = mapper;
        }
        // GET: api/<TasksController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserTasks()
        {
            // 1. שליפת ה-ID של המשתמש ישירות מהטוקן (הערך 11 שראינו ב-NameIdentifier)
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int currentUserId))
            {
                return Unauthorized("לא ניתן לזהות את מזהה המשתמש מהטוקן");
            }

            // 2. הבאת כל המשימות
            var allTasks = await _Taskervice.GetAllAsync();

            // 3. סינון המשימות לפי ה-ClientId (המספר 11)
            var userTasks = allTasks
                .Where(t => t.ClientId == currentUserId)
                .Select(t => new TaskDTO
                {
                    Code = t.Code, // ה-ID הייחודי של המשימה
                    Name = t.Name,
                    IsCompleted = t.IsCompleted,
                    Category = t.Category
                })
                .ToList();

            return Ok(userTasks);
        }


        // GET api/<TasksController>/5
        [HttpGet("{code}")]
        public async Task<ActionResult> Get(int code)
        {
            var t =await _Taskervice.GetByIdAsync(code);
            var cdTO = _mapper.Map<TaskDTO>(t);

            if (t == null)
            {
                return NotFound();
            }
            return Ok(cdTO);
        }

        // POST api/<TasksController>
        [HttpPost]
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TasksPostModel value)
        {
            // 1. בדיקה אם המשימה כבר קיימת (הבדיקה הזו תעבוד עכשיו בזכות התיקון ב-Repository)
         
            var clientIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(clientIdString))
            {
                return Unauthorized("User ID not found in token");
            }
            // 2. יצירת האובייקט והוספת ה-ID של המשתמש מה-Token
            var newTask = new Tasks
            {
                Name = value.Name,
                Category = value.Category,
                IsCompleted = false,
                ClientId = int.Parse(clientIdString) // כאן אנחנו מקשרים את המשימה ללקוח!
            };

            await _Taskervice.PostAsync(newTask);
            return Ok(value);
        }
        // PUT api/<TasksController>/5
        [HttpPut("{code}")]
        public async Task<ActionResult> Put(int code, [FromBody] TasksPostModel value)
        {
            var s = new Tasks { Name = value.Name, Category = value.Category };
            var c =await _Taskervice.GetByIdAsync(code);
            if (c == null)
            {
                //נתון לויכוח  - האם להחזיר לא נמצא או להחזיר שגיאה בבקשה
                return NotFound();
            }
           await _Taskervice.PutAsync(code, s);
            return Ok(c);

        }

        // DELETE api/<TasksController>/5
        [HttpDelete("{code}")]
        public async Task<ActionResult> Delete(int code)
        {
            var t =await _Taskervice.GetByIdAsync(code);
            if (t == null)
            {
                return BadRequest();
            }
           await _Taskervice.DeleteAsync(code);
            return Ok();
        }

    }
}
