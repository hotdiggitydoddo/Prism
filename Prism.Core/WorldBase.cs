using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Core
{
    public abstract class WorldBase
    {
        public EntityManager EntityManager { get; }
        public SubsystemManager SubsystemManager { get; }

        protected WorldBase(int maxEntities)
        {
            EntityManager = new EntityManager(this, maxEntities);
            SubsystemManager = new SubsystemManager(this);
        }
    }
}
