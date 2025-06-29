using UnityEngine.Events;

namespace Core
{
    // enumŸ���� �޾Ƽ� ���¸� �����ϴ� Ŭ����
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