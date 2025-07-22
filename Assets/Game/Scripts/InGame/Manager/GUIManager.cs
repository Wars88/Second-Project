namespace InGame
{
    public class GUIManager : Core.Manager
    {
        // ============================================================
        [ReadOnly] public DialogueViewer DialogueViewer;

        // ============================================================

        public override void Preparing()
        {
            DialogueViewer = gameObject.GetComponentInChildren<DialogueViewer>(true);

        }
    }
}