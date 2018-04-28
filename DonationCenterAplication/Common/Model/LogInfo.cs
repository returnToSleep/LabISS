using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    [Serializable]
    public class LogInfo
    {
        public virtual string username { get; set; }
        public virtual string password { get; set; }
        public virtual int id { get; set; }
        public virtual string type { get; set; }

        public LogInfo() { }

        public LogInfo(string username, string password, int id, string type)
        {
            this.username = username;
            this.password = password;
            this.id = id;
            this.type = type;
        }

        public override string ToString()
        {
            return username + " " + password + " Type: " + type + " Id: " + id;
        }

    }
}
