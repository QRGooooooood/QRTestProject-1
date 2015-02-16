using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Activity.TestProject.Helpers;
using Activity.TestProject.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Activity.TestProject
{
    [TestClass]
    public class UserControllerTest:BaseTest
    {
        [TestMethod]
        public void GetToken()
        {
            string url = this.HostName + "oauth2/authorize";
            string contentType = "application/x-www-form-urlencoded";
            var userModel = new UserGrantModel()
                                {
                                    UserName = "13512345678",
                                    Password = "123456"
                                };
            var result = CustomerHttpClient.Instance
                .SendPostRequest(url, userModel, null, "application/x-www-form-urlencoded");
            Debug.Write(result);
        }
    }
}
