using Core;
using UnityEngine;

namespace Lobby
{
    public partial class InputManager : Core.Manager
    {
        public enum States
        {
            Lobby,
            Inventory,
            Equipment,
            Monster,
            Item,
        }

        [ReadOnly][SerializeField] StateMachine<States> _stateMachine;

        public override void Preparing()
        {
            _stateMachine = new StateMachine<States>();
        }

        public override void StartUp()
        {
            BindLobbyInputEvent();
            BindInventoryInputEvent();
            BindItemInputEvent();

            _stateMachine.SetDefaultState(States.Lobby);
            _stateMachine.Change(States.Lobby);
        }
    }
}