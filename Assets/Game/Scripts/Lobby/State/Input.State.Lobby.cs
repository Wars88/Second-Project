using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

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

            }

			var state = new State<States>(States.Lobby);
			state.OnEnterEvent = OnEnter;

			_stateMachine.Add(state);

			// ==================================================================
			var viewers = guiManager.GetUIComponents<Viewer>();

            foreach (var viewer in viewers)
            {
				if (viewer.GetType() == typeof(LobbyViewer)) { viewer.Show(); }
				else { viewer.Hide(); }
            }

            guiManager.BackButton.Hide();
            guiManager.HomeButton.Hide();

			guiManager.GameStartButton.OnClickEvent = () => SceneManager.LoadScene("InGame");
			guiManager.InventoryButton.OnClickEvent = () => _stateMachine.Push(States.Inventory);
            guiManager.EquipmentButton.OnClickEvent = () => Debug.Log("장비");
            guiManager.MonsterButton.OnClickEvent = () => Debug.Log("몬스터");

        }
    }
}
