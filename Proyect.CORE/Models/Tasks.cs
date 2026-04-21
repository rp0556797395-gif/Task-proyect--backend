using System.ComponentModel.DataAnnotations;

namespace Proyect.Core.Models
{
    public class Tasks
    {

        [Key]
        public int Code { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public bool IsCompleted { get; set; }
        public int ClientId { get; set; }
        public Clients Client { get; set; }

    }
    public enum Category
    {
        Work,
        Personal,
        Home
    }
}
