using Core;

namespace InGame
{
    public class DialogueViewer : Viewer
    {
        public DialogueText DialogueText;
        public Image IconImage; 

        private void Awake()
        {
            DialogueText = GetComponentInChildren<DialogueText>(true);
            IconImage = GetComponentInChildren<Image>(true);
        }
    }
}