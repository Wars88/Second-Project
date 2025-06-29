using System.Collections.Generic;
using UnityEngine;

namespace Lobby
{ 
    public class PlayerPrefsManager : Core.Manager
    {
        public ItemTable _itemTable;
        public List<ItemRowData> _items;

        public override void Preparing()
        {
            _itemTable = new ItemTable();
        }

        public override void StartUp()
        {
            _itemTable.Road("Tables/ItemTable");
            _items = _itemTable.GetRows<ItemRowData>(); 
        }
    }
}
