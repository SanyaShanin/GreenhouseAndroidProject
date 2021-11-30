using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

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
    }
}
