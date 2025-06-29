using UnityEngine.Events;

namespace Core
{
    // enum타입을 받아서 상태를 관리하는 클래스
    public class State<T> where T : struct
    {
        public State(T id) { Id = id; }
        public T Id { get; private set; }

        public UnityAction OnEnterEvent;
        public UnityAction OnExitEvent;

        public void OnEnter() => OnEnterEvent?.Invoke();

        public void OnExcute() { }

        public void OnExit() => OnExitEvent?.Invoke();
    }
}