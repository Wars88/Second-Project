using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public abstract class Client : MonoBehaviour
    {
        [ReadOnly][SerializeField] List<Manager> _managers = new List<Manager>();
        [ReadOnly][SerializeField] bool _isStartUp;

        private void Update()
        {
            if (!_isStartUp) 
            { 
                Debug.LogError("클라이언트가 시작되지 않았습니다. StartUp()을 호출해야 합니다.");
                return;
            }

            foreach (var manager in _managers) { manager.OnUpdate(); }
        }

        public void StartUp() => _isStartUp = true;

        public void AddManager(Manager manager) => _managers.Add(manager);

        public List<Manager> GetManagers() => _managers;

        public T GetManager<T>() where T : Manager
        {
            var manager = _managers.Find(m => m is T) as T;

            if (manager != null) { return manager; }
            else
            {
                Debug.LogError("매니저가 없거나 변환 불가: " + typeof(T).Name);
                return null;
            }
        }

    }
}