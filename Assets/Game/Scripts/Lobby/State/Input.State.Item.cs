using Core;
using UnityEngine;

namespace Lobby
{
    public partial class InputManager
    {
        private void BindItemInputEvent()
        {
            var guiManager = Client.GetManager<GUIManager>();

            void OnEnter()
            {
                Debug.Log("OnEnter Item State");

                var viewer = guiManager.ItemViewer;
                viewer.Show();

                var back = guiManager.BackButton;
                back.Show();
                back.OnClickEvent = () => _stateMachine.Pop();

                var home = guiManager.HomeButton;
                home.Show();
                home.OnClickEvent = () => _stateMachine.PopAll();

                var dataManager = Client.GetManager<DataManager>();
                var image = viewer.GetComponentInChildren<Image>();
                var texts = viewer.GetComponentsInChildren<Text>();

                dataManager.ItemRefrash(_itemButtonIndex, image, texts);
            }

            void OnExit()
            {
                Debug.Log("OnExit Item State");

                var viewer = guiManager.ItemViewer;
                viewer.Hide();

                var back = guiManager.BackButton;
                back.Hide();
                back.OnClickEvent = null;

                var home = guiManager.HomeButton;
                home.Hide();
                home.OnClickEvent = null;
            }

            var state = new State<States>(States.Item);
            state.OnEnterEvent = OnEnter;
            state.OnExitEvent = OnExit;

            _stateMachine.Add(state);
        }
    }
}