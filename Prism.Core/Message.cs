using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Core
{
    public struct Message
    {
        public int Type { get; }
        public uint Sender { get; }
        public uint Receiver { get; }

        public Message(int type, uint sender, uint receiver)
        {
            Type = type;
            Sender = sender;
            Receiver = receiver;
        }
    }
}
