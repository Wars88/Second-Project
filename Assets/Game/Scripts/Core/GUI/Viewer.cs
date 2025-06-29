using UnityEngine;

namespace Core
{
    public class Viewer : MonoBehaviour
    {
        public void Show() => gameObject.SetActive(true);

        public void Hide() => gameObject.SetActive(false);
    }
}