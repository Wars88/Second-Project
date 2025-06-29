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
                Debug.LogError("Ŭ���̾�Ʈ�� ���۵��� �ʾҽ��ϴ�. StartUp()�� ȣ���ؾ� �մϴ�.");
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
                Debug.LogError("�Ŵ����� �������� �ʽ��ϴ�: " + typeof(T).Name);
                return null;
            }
        }

    }
}