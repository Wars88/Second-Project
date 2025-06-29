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

				// 로비뷰어는 끄지 않을 거라서 여기 X
            }

			var state = new State<States>(States.Lobby);
			state.OnEnterEvent = OnEnter;

			_stateMachine.Add(state);

			// ==================================================================
			// 로비 버튼이벤트
			var viewers = guiManager.GetUIComponents<Viewer>();

            foreach (var viewer in viewers)
            {
				if (viewer.GetType() == typeof(LobbyViewer)) { viewer.Show(); }
				else { viewer.Hide(); }
            }

            guiManager.BackButton.Hide();
            guiManager.HomeButton.Hide();

            guiManager.GameStartButton.OnClickEvent = () => Debug.Log("게임스타트");
			guiManager.InventoryButton.OnClickEvent = () => _stateMachine.Push(States.Inventory);
            guiManager.EquipmentButton.OnClickEvent = () => Debug.Log("장비");
            guiManager.MonsterButton.OnClickEvent = () => Debug.Log("몬스터 도감");

        }
    }
}
