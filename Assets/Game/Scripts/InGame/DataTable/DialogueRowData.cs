using UnityEngine;

namespace InGame
{
    [System.Serializable]
    public class DialogueRowData : Core.RowData
    {
        public string Chapter
        {
            get { return _chapter; }
        }
        public string Name
        {
            get { return _name; }
        }
        public string IconPath
        {
            get { return _iconPath; }
        }
        public string Dialogue
        {
            get { return _dialogue; }
        }

        public DialogueRowData(int index, string chapter, string name, string iconPath, string dialogue) : base(index)
        {
            _chapter = chapter;
            _name = name;
            _iconPath = iconPath;
            _dialogue = dialogue;
        }


        [ReadOnly][SerializeField] string _chapter;
        [ReadOnly][SerializeField] string _name;
        [ReadOnly][SerializeField] string _iconPath;
        [ReadOnly][SerializeField] string _dialogue;
    }
}