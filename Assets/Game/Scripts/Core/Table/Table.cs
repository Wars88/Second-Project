using System.Collections.Generic;
using static UnityEngine.Rendering.DebugUI.Table;

namespace Core
{
    public abstract class Table
    { 
        private List<RowData> _rows = new List<RowData>();

        public abstract void Road(string path);

        public T GetRowDataByIndex<T>(int index) where T : RowData
        {
            return _rows[index] as T;
        }

        protected void Add(RowData row) => _rows.Add(row);

        public List<T> GetRows<T>()
        {
            return _rows as List<T>;
        }
    }
}