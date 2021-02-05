using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NK_DataManagerLibrary.Models
{
    public class UserModel
    {
        public string AuthUserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public DateTime CreateDate { get; set; }
    }

}
