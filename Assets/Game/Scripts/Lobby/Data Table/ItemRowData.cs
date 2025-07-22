using UnityEngine;

namespace Lobby
{
    [System.Serializable]
    public class ItemRowData : Core.RowData
    {
        public string Name
        {
            get { return _name; }
        }
        public string ResourcePath
        {
            get { return _resourcePath; }
        }
        public string Description
        {
            get { return _discription; }
        }

        public ItemRowData(int index, string name, string resourcePath, string discription) : base(index)
        {
            _name = name;
            _resourcePath = resourcePath;
            _discription = discription;
        }

        [ReadOnly][SerializeField] string _name;
        [ReadOnly][SerializeField] string _resourcePath;
        [ReadOnly][SerializeField] string _discription;
    }
}
