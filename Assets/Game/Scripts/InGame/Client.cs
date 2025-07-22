using UnityEngine;

namespace InGame
{
    public class Client : Core.Client
    {
        private GUIManager _guiManager;
        private InputManager _inputManager;
        private DataManager _dataManager;

        private void Awake()
        {
            _guiManager = GameObject.FindAnyObjectByType<GUIManager>();
            _guiManager.SetClient(this);
            _inputManager = GameObject.FindAnyObjectByType<InputManager>();
            _inputManager.SetClient(this);
            _dataManager = GameObject.FindAnyObjectByType<DataManager>();
            _dataManager.SetClient(this);
        }

        private void Start()
        {
            foreach (var manager in GetManagers())
            {
                manager.Preparing();
            }

            foreach (var manager in GetManagers())
            {
                manager.StartUp();
            }

            StartUp();
        }
    }
}