using UnityEngine;

namespace Lobby
{
    public class Client : Core.Client
    {
        private GUIManager _guiManager;
        private InputManager _inputManager;

        // Awake()���� �Ŵ����� ���.
        private void Awake()
        {
            _guiManager = GameObject.FindAnyObjectByType<GUIManager>();
            _guiManager.SetClient(this);
            _inputManager = GameObject.FindAnyObjectByType<InputManager>();
            _inputManager.SetClient(this);
        }

        // ���߿� �ڷ�ƾ���� ȭ����ȯ�� ���� ó���� �� �ֵ���.
        private void Start()
        {
            {
                var managers = GetManagers();
                foreach (var manager in managers) { manager.Preparing(); }
            }

            {                 
                var managers = GetManagers();
                foreach (var manager in managers) { manager.StartUp(); }
            }

            // �ʱ�ȭ �� �غ��۾� �Ϸ�
            StartUp();
        }
    }
}