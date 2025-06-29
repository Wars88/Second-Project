using Core;
using UnityEngine;

namespace Lobby
{
	public partial class InputManager
	{
		private void BindLobbyInputEvent()
		{
			var guiManager = Client.GetManager<GUIManager>();

			void OnEnter()
			{
                Debug.Log("OnEnter Lobby State");

				// �κ���� ���� ���� �Ŷ� ���� X
            }

			var state = new State<States>(States.Lobby);
			state.OnEnterEvent = OnEnter;

			_stateMachine.Add(state);

			// ==================================================================
			// �κ� ��ư�̺�Ʈ
			var viewers = guiManager.GetUIComponents<Viewer>();

            foreach (var viewer in viewers)
            {
				if (viewer.GetType() == typeof(LobbyViewer)) { viewer.Show(); }
				else { viewer.Hide(); }
            }

            guiManager.BackButton.Hide();
            guiManager.HomeButton.Hide();

            guiManager.GameStartButton.OnClickEvent = () => Debug.Log("���ӽ�ŸƮ");
			guiManager.InventoryButton.OnClickEvent = () => _stateMachine.Push(States.Inventory);
            guiManager.EquipmentButton.OnClickEvent = () => Debug.Log("���");
            guiManager.MonsterButton.OnClickEvent = () => Debug.Log("���� ����");

        }
    }
}
