using Proyect.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyect.Core.DTO
{
    public class TaskDTO
    {

        [Key]
        public int Code { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public bool IsCompleted { get; set; }

    }
           
}
