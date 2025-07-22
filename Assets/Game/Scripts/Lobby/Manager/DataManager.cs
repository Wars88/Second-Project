using Core;
using System.Collections.Generic;
using UnityEngine;

namespace Lobby
{ 
    public class DataManager : Core.Manager
    {
        public ItemTable _itemTable;
        
        [ReadOnly][SerializeField] List<ItemRowData> _items;

        public override void Preparing()
        {
            _itemTable = new ItemTable();
        }

        public override void StartUp()
        {
            _itemTable.Road("Tables/ItemTable");
            _items = _itemTable.GetRows<ItemRowData>();
        }

        public void ItemButtonInit(IEnumerable<ItemButton> items)
        {
            int index = 0;

            foreach (var item in items)
            {
                if (index >= _itemTable.Count()) { return; }

                var rawData = _itemTable.GetRowDataByIndex<ItemRowData>(index);
                
                if (rawData != null) { item.Init(rawData.ResourcePath, rawData.Name); }

                index++;
            }
        }

        public void ItemRefrash(int index, Image image, Text[] texts)
        {
            if (index < _items.Count)
            {
                image.SetImage(_itemTable.GetRowDataByIndex<ItemRowData>(index).ResourcePath);
                texts[0].SetText(_itemTable.GetRowDataByIndex<ItemRowData>(index).Name);
                texts[1].SetText(_itemTable.GetRowDataByIndex<ItemRowData>(index).Description);
            }
        }
    }
}
