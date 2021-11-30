using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SmartGreenhouse4.Apis.Models
{
    public class User
    {
        string name = "";
        string login = "";
        string mail = "";
        string status = "";
        string[] greenhouses;
        public User()
        {

        }
        public static User FromJSON(string json)
        {
            return JsonConvert.DeserializeObject<User>(json);
        }
    }
}
