
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

                string name = dictionaryRow["name"].ToString();
                string description = dictionaryRow["description"].ToString();

                var itemRow = new ItemRowData(i, name, description);

                Add(itemRow);
            }
        }
    }
}
