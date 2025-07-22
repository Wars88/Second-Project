using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public abstract class Table
    { 
        private List<RowData> _rows = new List<RowData>();

        public abstract void Road(string path);
        
        public int Count() => _rows.Count;

        public T GetRowDataByIndex<T>(int index) where T : RowData
        {
            return _rows[index] as T;
        }


        protected void Add(RowData row) => _rows.Add(row);

        public List<T> GetRows<T>() where T : RowData
        {
            return _rows.OfType<T>().ToList();  
        }
    }
}