using Core;
using UnityEngine;

namespace Lobby
{
    public partial class InputManager
    {
        private void BindInventoryInputEvent()
        {
            var guiManager = Client.GetManager<GUIManager>();

            // ==================================================================

            void OnEnter()
            {
                Debug.Log("OnEnter Inventory State");

                var viewer = guiManager.InventoryViewer;
                viewer.Show();

                var back = guiManager.BackButton;
                back.Show();

                back.OnClickEvent = () =>
                {
                   // 백버튼 클릭이벤트 재등록
                    _stateMachine.Pop();
                };

                var home = guiManager.HomeButton;
                home.Show();
                home.OnClickEvent = () =>
                {
                    _stateMachine.PopAll();

                };

                // 각 아이템버튼들이 자체적으로 초기화 함수를 가지고 있음
                var dataManager = Client.GetManager<DataManager>();
                dataManager.ItemButtonInit(guiManager.ItemButtons);
            }
            
            void OnExit()
            {
                Debug.Log("OnExit Inventory State");

                var viewer = guiManager.InventoryViewer;
                viewer.Hide();

                var back = guiManager.BackButton;
                back.Hide();
                back.OnClickEvent = null;

                var home = guiManager.HomeButton;
                home.Hide();
                home.OnClickEvent = null;
            }

            var state = new State<States>(States.Inventory);
            state.OnEnterEvent = OnEnter;
            state.OnExitEvent = OnExit;

            _stateMachine.Add(state);

            // ==================================================================
            // 각 아이템 버튼들은 상태마다 다르게 이벤트를 등록할 필요가 없기에 onEnter에서 등록X
            foreach (var button in guiManager.ItemButtons)
            {
                button.OnClickEvent = () =>
                {
                    _itemButtonIndex = button.Index;

                    _stateMachine.Push(States.Item);
                };
            }
        }
    }
}