using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class User : BaseEntity
    {
        // First name of the user.
        public string FirstName { get; set; }

        // Last name of the user.
        public string LastName { get; set; }

        // Email Id of the user.
        public string Email { get; set; }

        // Profile picture URL of user.
        public string ProfilePicUrl { get; set; }

        // One USer might have 1 or more Account (1:Many relationship)
        public virtual Account Account { get; set; }
    }
}
