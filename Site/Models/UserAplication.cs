using Microsoft.AspNet.Identity.EntityFramework;

namespace Site.Models
{
    public class UserAplication : IdentityUser
    {
        public string FullName { get; set; }
    }
}