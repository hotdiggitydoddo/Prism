using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Core
{
    public class SubsystemManager
    {
        private List<Subsystem> _subsystems;
        private Messenger _messenger;
        private WorldBase _world;
        public SubsystemManager(WorldBase world)
        {
            _world = world;
            _messenger = new Messenger();
            _subsystems = new List<Subsystem>();
        }

        public void OnComponentChanged(uint entity)
        {
            var mask = _world.EntityManager.GetComponentMask(entity);
            foreach (var subsystem in _subsystems)
            {
                subsystem.OnComponentChanged(entity, mask);
            }
        }

        public void AddSubsystem(Subsystem system)
        {
            if (_subsystems.Contains(system)) return;
            _subsystems.Add(system);
            system.Init(this, _world.EntityManager);
            _messenger.AddObserver(system);
        }

        public void RemoveSubsystem(Subsystem system)
        {
            if (!_subsystems.Contains(system)) return;
            _subsystems.Remove(system);
            _messenger.RemoveObserver(system);
        }

        public void Update(float dt)
        {
            foreach(var subsystem in _subsystems)
                subsystem.Update(dt);
        }

        public void BroadcastMessage(IMessage message)
        {
            _messenger.Broadcast(message);
        }
        
    }
}
