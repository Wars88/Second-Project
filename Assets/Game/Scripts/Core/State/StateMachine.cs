using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    [System.Serializable]
    public class StateMachine<T> where T : struct
    {
        [ReadOnly][SerializeField] List<string> _debugForStack = new List<string>();
        [ReadOnly][SerializeField] string _debugForCurrentState;
        [ReadOnly][SerializeField] string _defaultState;

        private List<State<T>> _states = new List<State<T>>();
        private Stack<State<T>> _stack = new Stack<State<T>>();
        private State<T> _currentState;
        public State<T> CurrentState
        {
            get => _currentState;
            private set
            {
                _currentState = value;
                _debugForCurrentState = _currentState.Id.ToString();
            }
        }

        // Enum타입의 id, States.Lobby 등
        public void Push(T id)
        {
            if (CurrentState != null) { CurrentState.OnExit(); }

            var next = _states.Find(s => s.Id.Equals(id));
            if (next != null)
            {
                CurrentState = next;
                _stack.Push(CurrentState);
                _debugForStack.Add(id.ToString());
                CurrentState.OnEnter();
            }
        }

        public void Pop()
        {
            CurrentState.OnExit();
            _stack.Pop();

            if (_stack.Count > 0)
            {
                var pre = _stack.Peek();

                if (pre != null)
                {
                    CurrentState = pre;
                    CurrentState.OnEnter();
                }
                _debugForStack.RemoveAt(_debugForStack.Count - 1);
            }
        }

        public void Change(T id)
        {
            if (CurrentState != null) { CurrentState.OnExit(); }

            var next = _states.Find(s => Equals(s.Id, id));
            CurrentState = next;
            CurrentState.OnEnter();

            // 스택 관리
            _stack.Clear();
            _debugForStack.Clear();

            _stack.Push(CurrentState);
            _debugForStack.Add(CurrentState.Id.ToString());
        }

        public void PopAll()
        {
            _currentState.OnExit();
            _stack.Clear();
            _debugForStack.Clear();

            CurrentState = _states.Find(s => Equals(_defaultState, s.Id.ToString()));
            CurrentState.OnEnter();

            _stack.Push(CurrentState);
            _debugForStack.Add(CurrentState.Id.ToString());
        }

        public void SetDefaultState(T id) => _defaultState = id.ToString();

        public void Add(State<T> state) => _states.Add(state);

        public void Remove(State<T> state) => _states.Remove(state);
    }
}