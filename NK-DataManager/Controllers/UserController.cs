using Microsoft.AspNet.Identity;
using NK_DataManagerLibrary.DataAccess;
using NK_DataManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace NK_DataManager.Controllers
{
    [Authorize]
    [RoutePrefix("api/Users")]
       public class UserController : ApiController
    {

        // GET: User/Details/5
        public UserModel GetById()
        {
            string userId = RequestContext.Principal.Identity.GetUserId();

            UserData data = new UserData();

            return data.GetUserById(userId).First()     ;
        }


    }
}
