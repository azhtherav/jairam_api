namespace TruckApi.Helper
{
    using System.Net.Http;
    using System.Linq;

    public class AdminUserValidation
    {
        public bool ValidateUserName(HttpRequestMessage objRequest)
        {
            var header = objRequest.Headers;
            string username = string.Empty, password = string.Empty;

            if (header.Contains("username") && header.Contains("password"))
            {
                username = header.GetValues("username").First();
                password = header.GetValues("password").First();

                if (username.Equals("ADMIN") && password.Equals("ADMIN"))
                {
                    return true;
                }
            }

            return false;
        }
    }
}