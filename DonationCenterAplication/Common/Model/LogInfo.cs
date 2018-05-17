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
        public virtual int? intId { get; set; }
        public virtual string type { get; set; }
        public virtual string varId { get; set; }

        public LogInfo() { }


        //For donation doctors and donors
        public LogInfo(string username, string password, int id, string type)
        {
            this.username = username;
            this.password = password;
            this.intId = id;
            this.type = type;
        }

        //For donation centers
        public LogInfo(string username, string password, string id, string type)
        {
            this.username = username;
            this.password = password;
            this.varId = id;
            this.type = type;
        }

        public override bool Equals(object other)
        {
            LogInfo o;
            try
            {
               o = (LogInfo)other;
            }catch (InvalidCastException)
            {
                return false;
            }

            return this.username == o.username && this.password == o.password;
        }
        

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        

    }
}
