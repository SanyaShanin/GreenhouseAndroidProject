using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;

namespace SmartGreenhouse4.Apis.Models
{
    public class Greenhouse
    {
        public string name { set; get; } = "Greenhouse";
        public string id { set; get; } = "";

        public Greenhouse()
        {

        }
        public Greenhouse(string id)
        {
            this.id = id;
            name = name + " " + id.Substring(0, 5);
        }
        public Greenhouse(string id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public static Greenhouse FromJSON(string json)
        {
            return JsonConvert.DeserializeObject<Greenhouse>(json);
        }
    }
}
