using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using SmartGreenhouse4.Apis;

namespace SmartGreenhouse4.Apis.Models
{
    public class User
    {
        public string name = "";
        public string login = "";
        public string mail = "";
        public string status = "";
        public string[] greenhouses;
        public User()
        {

        }
        public static User FromJSON(string json)
        {
            return JsonConvert.DeserializeObject<User>(json);
        }
        public async Task<bool> Refresh(string session)
        {
            var result = await Backend.GetUser(session);
            if (!result.success || result.content == "session") return false;

            var rUser = FromJSON(result.content);
            name = rUser.name;
            login = rUser.login;
            mail = rUser.mail;
            status = rUser.status;
            greenhouses = rUser.greenhouses;

            return true;
        }
    }
}
