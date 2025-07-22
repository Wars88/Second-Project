using UnityEngine;
using UnityEngine.UIElements;


namespace Core
{
    public class Image : MonoBehaviour
    {
        private UnityEngine.UI.Image _image;

        private void Awake()
        {
            _image = GetComponent<UnityEngine.UI.Image>();
        }

        public void SetImage(string path)
        {
            Sprite sprite = Resources.Load<Sprite>(path);

            if (sprite != null) { _image.sprite = sprite; }
        }
    }
}