using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Core
{
    public interface IObserver
    {
        void Notify(IMessage message);
    }
}
