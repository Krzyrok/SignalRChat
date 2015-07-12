using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRChat
{
    public class ChatHub : Hub
    {
        private static List<string> _messages = new List<string>();

        public void Message(string message)
        {
            _messages.Add(message);
            Clients.All.broadcastMessage(message);
        }

        public override System.Threading.Tasks.Task OnConnected()
        {
            foreach (var message in _messages)
                Clients.Caller.broadcastMessage(message);

            return base.OnConnected();
        }
    }
}