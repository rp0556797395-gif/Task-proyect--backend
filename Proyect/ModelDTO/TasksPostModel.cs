using Proyect.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Proyect.ModelDTO
{
    public class TasksPostModel
    {
        public string Name { get; set; }
        public Category  Category{ get; set; }

    }
    

}
