using UnityEngine;

namespace Lobby
{
    [System.Serializable]
    public class ItemRowData : Core.RowData
    {
        public ItemRowData(int index, string name, string discription) : base(index)
        {
            _name = name;
            _discription = discription;
        }

        [ReadOnly][SerializeField] string _name;
        [ReadOnly][SerializeField] string _discription;
    }
}
