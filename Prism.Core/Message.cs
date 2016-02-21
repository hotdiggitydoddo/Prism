using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Core
{
    public interface IMessage
    {
        int Type { get; }
        uint Sender { get; }
        //uint Receiver { get; }

        //public Message(int type, uint sender, uint receiver)
        //{
        //    Type = type;
        //    Sender = sender;
        //    Receiver = receiver;
        //}
    }
}
