using UnityEngine;

namespace Core
{
    public class  ViewerButton : Button
    {
        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);
    }
}