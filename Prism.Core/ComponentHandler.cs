using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Core
{
    public interface IComponentHandler
    {
      //  int TypeId();
    }

    public class ComponentHandler<T> : IComponentHandler where T : IComponent, new()
    {
        private readonly T[] _components;
        private readonly List<int> _activeComponentIndices;
        private readonly List<int> _freeComponentIndices;
        private readonly int _typeId;

        public ComponentHandler(int maxEntities)
        {
          //  _typeId = typeId;

            _components = new T[maxEntities];
            _activeComponentIndices = new List<int>();
            _freeComponentIndices = new List<int>();

            for (int i = 0; i < _components.Length; i++)
            {
                _components[i] = new T();
                _freeComponentIndices.Add(i);
            }
        }

        public T AssignComponentToEntity(uint entity)
        {
            _freeComponentIndices.Remove((int)entity);
            _activeComponentIndices.Add((int)entity);
            _components[entity].Init();
            return _components[entity];
        }

        public void RemoveComponentFromEntity(uint entity)
        {
            _activeComponentIndices.Remove((int)entity);
            _freeComponentIndices.Add((int)entity);
        }

        public T GetComponent(uint entity)
        {
            return _components[entity];
        }

        public List<int> GetEntities()
        {
            return _activeComponentIndices;
        }

        public int TypeId()
        {
            return _typeId;
        }
    }
}
