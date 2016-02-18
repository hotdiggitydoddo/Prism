using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Core
{
    public class Messenger
    {
        private List<IObserver> _observers;

        public Messenger()
        {
            _observers = new List<IObserver>();
        } 

        public bool AddObserver(IObserver observer)
        {
            if (HasObserver(observer)) return false;
            _observers.Add(observer);
            return true;
        }

        public bool HasObserver(IObserver observer)
        {
            return _observers.Contains(observer);
        }

        public bool RemoveObserver(IObserver observer)
        {
            if (!HasObserver(observer)) return false;
            _observers.Remove(observer);
            return true;
        }

        public void Broadcast(Message message)
        {
            foreach (var observer in _observers)
                observer.Notify(message);
        }
    }
}
