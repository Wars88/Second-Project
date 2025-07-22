using System;
using Core;

namespace Lobby
{
    // 아이템 버튼은 버튼에 텍스트와 이미지
    public class ItemButton : Core.Button
    {
        public Action<int> OnItemButtonClickEvent;

        public int Index { get; set; }
        public Image Image { get; private set; }
        public Text Text { get; private set; }

        private void Awake()
        {
            Image = gameObject.GetComponent<Image>();
            Text = gameObject.GetComponentInChildren<Text>();
        }

        public void Init(string resourcePath, string name)
        {
            Image.SetImage(resourcePath);
            Text.SetText(name);
        }
    }
}