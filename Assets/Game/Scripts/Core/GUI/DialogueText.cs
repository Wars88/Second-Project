using System.Collections;
using UnityEngine;

namespace Core
{
    public class DialogueText : Text
    {
        private Coroutine _typingCoroutine;

        private void StopTyping()
        {
            if (_typingCoroutine != null)
            {
                StopCoroutine(_typingCoroutine);
                _typingCoroutine = null;
                
                SetText(string.Empty);
            }
        }

        public void StartTyping(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                SetText(string.Empty);
                return;
            }

            StopTyping();

            _typingCoroutine = StartCoroutine(StartTypingRoutine(text));
        }

        private IEnumerator StartTypingRoutine(string text)
        {
            float typingSpeed = 0.05f;
            string tempText = string.Empty;

            foreach (char c in text)
            {
                tempText += c;
                SetText(tempText);

                if (c != ' ') { yield return new WaitForSeconds(typingSpeed); }
            }

            _typingCoroutine = null;
        }
    }
}