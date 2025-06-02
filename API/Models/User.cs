using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    public class User : IdentityUser
    {
        public bool FisrtLogin { get; set;  } = true ; 
    }
}
