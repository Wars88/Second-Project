using UnityEngine;

namespace Core
{
    public class  Manager : MonoBehaviour
    {
        protected Client Client { get; private set; }

        public void SetClient(Client client)
        {
            Client = client;
            Client.AddManager(this);
        }

        public virtual void Preparing() { }
        public virtual void StartUp() { }
        public virtual void OnUpdate() { }
    }
}