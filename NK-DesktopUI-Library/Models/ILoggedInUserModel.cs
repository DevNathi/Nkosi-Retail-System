using System;

namespace NK_DesktopUI_Library.Models
{
    public interface ILoggedInUserModel
    {
        public string Token { get; set; }
        public string AuthUserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

        public DateTime CreateDate { get; set; }
    }
}