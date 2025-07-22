using UnityEngine;

namespace Lobby
{
    public class Client : Core.Client
    {
        private GUIManager _guiManager;
        private InputManager _inputManager;
        private DataManager _dataManager;

        // Awake()에서 매니저들 등록
        private void Awake()
        {
            _guiManager = GameObject.FindAnyObjectByType<GUIManager>();
            _guiManager.SetClient(this);
            _inputManager = GameObject.FindAnyObjectByType<InputManager>();
            _inputManager.SetClient(this);
            _dataManager = GameObject.FindAnyObjectByType<DataManager>();
            _dataManager.SetClient(this);

        }

        // 나중에 코루틴으로 화면전환과 같이 처리할 수 있도록.
        private void Start()
        {
            // 화면전환

            // 구글 인증 등.

            {
                var managers = GetManagers();
                foreach (var manager in managers) { manager.Preparing(); }
            }

            {                 
                var managers = GetManagers();
                foreach (var manager in managers) { manager.StartUp(); }
            }

            // 초기화 및 준비작업 완료
            StartUp();
        }
    }
}