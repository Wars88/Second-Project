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
            // �κ��丮 State �߰�

            void OnEnter()
            {
                Debug.Log("OnEnter Inventory State");

                var viewer = guiManager.InventoryViewer;
                viewer.Show();

                var back = guiManager.BackButton;
                back.Show();

                back.OnClickEvent = () =>
                {
                    // Ȯ�ξ��� �κ��丮 �������� �ִ��� �˻�
                    // �˾� ����

                    _stateMachine.Pop();
                };

                var home = guiManager.HomeButton;
                home.Show();
                home.OnClickEvent = () =>
                {
                    _stateMachine.PopAll();

                };
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
            // item ��ư�� �̺�Ʈ ���
            foreach(var button in guiManager.ItemButtons)
            {
                button.OnClickEvent = () => _stateMachine.Push(States.Item);
            }
        }
    }
}