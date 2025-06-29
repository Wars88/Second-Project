using UnityEngine;
using UnityEngine.Events;

namespace Core
{
    public class Button : MonoBehaviour
    {
        public UnityAction OnClickEvent;

        protected virtual void Start()
        {
            var buttonComponent = gameObject.GetComponent<UnityEngine.UI.Button>();
            buttonComponent.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            OnClickEvent?.Invoke();
        }
    }
}