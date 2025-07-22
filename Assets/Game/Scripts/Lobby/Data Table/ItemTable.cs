

using UnityEngine;

namespace Lobby
{
    public class ItemTable : Core.Table
    {
        public override void Road(string path)
        {
            var list = CSVReader.Read(path);

            for(int i = 0; i < list.Count; i++)
            {
                var dictionaryRow = list[i];
                
                string name = dictionaryRow["Name"].ToString();
                string resourcePath = dictionaryRow["Path"].ToString();
                string description = dictionaryRow["Description"].ToString();
                
                var itemRow = new ItemRowData(i, name, resourcePath, description);

                Add(itemRow);
            }
        }
    }
}
