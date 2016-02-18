using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Core
{
    public abstract class Subsystem : IObserver
    {
        private BitSet _componentTypes { get; }
        protected List<uint> Entities { get; } 
        public abstract void Notify(Message message);

        protected Subsystem(params int[] componentTypes)
        {
            _componentTypes = new BitSet();
            foreach (var componentType in componentTypes)
                _componentTypes.SetBit(componentType);
        }

        public void OnComponentAdded(uint entity, BitSet componentMask)
        {
            if (_componentTypes.IsSubsetOf(componentMask))
                Entities.Add(entity);
        }
        public abstract void Update(float dt);
    }
   
}
