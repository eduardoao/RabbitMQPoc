
namespace Domain.Entities
{
    public class Usuario : Base
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public int Password { get; set; }
        public string Email { get; set; }
    }
}
