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
        private EntityManager _em;

        public SubsystemManager(EntityManager em)
        {
            _em = em;
            _subsystems = new List<Subsystem>();
        }

        public void OnComponentChanged(uint entity)
        {
            var mask = _em.GetComponentMask(entity);
            foreach (var subsystem in _subsystems)
            {
                subsystem.OnComponentChanged(entity, mask);
            }
        }

        public void AddSubsystem(Subsystem system)
        {
            if (_subsystems.Contains(system)) return;
            _subsystems.Add(system);
            system.Init(this, _em);
        }

        public void RemoveSubsystem(Subsystem system)
        {
            if (!_subsystems.Contains(system)) return;
            _subsystems.Remove(system);
        }

        public void Update(float dt)
        {
            foreach(var subsystem in _subsystems)
                subsystem.Update(dt);
        }

        
    }
}
