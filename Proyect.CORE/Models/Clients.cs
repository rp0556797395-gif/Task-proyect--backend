namespace Proyect.Core.Models
{
    public class Clients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string adress { get; set; }
        public string mail { get; set; }
        public List<Tasks> listtasks { get; set; }
    }
}
