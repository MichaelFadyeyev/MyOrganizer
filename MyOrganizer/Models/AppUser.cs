using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MyOrganizer.Models
{
    public class AppUser : IdentityUser
    {        
        // навігаційні властивості
        #region navigation props
        public virtual List<MyTask> Tasks { get; set; }
        #endregion
    }
}
