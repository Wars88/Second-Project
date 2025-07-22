using UnityEngine;
using TMPro;

namespace Core
{
    public class Text : MonoBehaviour
    {
        private TextMeshProUGUI _TextMeshProUGUI;

        private void Awake()
        {
            _TextMeshProUGUI = GetComponent<TextMeshProUGUI>();
        }

        public void SetText(string text) => _TextMeshProUGUI.text = text;
    }
}