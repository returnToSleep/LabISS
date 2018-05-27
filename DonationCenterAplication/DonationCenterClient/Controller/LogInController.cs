using Common.Exceptions;
using Common.Model;
using DonationCenterAplication.Remoting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace Client.Controller
{


    class LogInController
    {

        private IService service;
        private string user;
        private string password;


        public LogInController(string user, string password, IService service)
        {
            this.user = user;
            this.password = password;
            this.service = service;
        }

        public LogInfo getAccount()
        {
            try
            {
                LogInfo info = service.GetOneFromDatabase<LogInfo>(user);
                if (info.password == password)
                    return info;
                return null;
            }catch (RemotingException rmE)
            {
                throw new ControllerException("A aparut o problema!", rmE);
            }catch (SocketException)
            {
                throw new ControllerException("Nu se poate efectua conexiunea la server\nIncercati din nou mai taziu");
            }
        }
    }
}
