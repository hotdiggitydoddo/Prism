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
        protected SubsystemManager SubsystemManager { get; private set; }
        public abstract void Notify(Message message);
        public abstract void RegisterComponentHandlers(EntityManager em);
        protected Subsystem(params int[] componentTypes)
        {
            _componentTypes = new BitSet();
            Entities = new List<uint>();
            foreach (var componentType in componentTypes)
                _componentTypes.SetBit(componentType);
        }

        public void OnComponentChanged(uint entity, BitSet componentMask)
        {
            if (_componentTypes.IsSubsetOf(componentMask))
                Entities.Add(entity);
            else
            {
                if (Entities.Contains(entity))
                    Entities.Remove(entity);
            }
        }
        public abstract void Update(float dt);

        internal void Init(SubsystemManager subsystemManager, EntityManager em)
        {
            SubsystemManager = subsystemManager;
            RegisterComponentHandlers(em);
        }
    }
   
}
