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
        }

        public void OnComponentAdded(uint entity)
        {
            var mask = _em.GetComponentMask(entity);
            foreach (var subsystem in _subsystems)
            {
                subsystem
            }
        }

        public void AddSubsystem(Subsystem system)
        {
            if (_subsystems.Contains(system)) return;
            _subsystems.Add(system);
        }

        public void RemoveSubsystem(Subsystem system)
        {
            if (!_subsystems.Contains(system)) return;
            _subsystems.Remove(system);
        }

        
    }
}
