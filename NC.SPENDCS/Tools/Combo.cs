using System.Data;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NC.SPENDCS.Tools
{
    public class Combo
    {
        public async Task<List<SelectListItem>> FNLLenaCombo<T>(List<T> itemsCbx, string sValue, string sText)
        {
            DataTable dtCBX = ToDataTable(itemsCbx);
            List<SelectListItem> CbxItem = new List<SelectListItem>();
            for (int K = 0; K < dtCBX.Rows.Count; K++)
            {
                CbxItem.Add(new SelectListItem
                {
                    Text = dtCBX.Rows[K].Field<string>(sText),
                    Value = dtCBX.Rows[K].Field<string>(sValue)
                });
            }
            return CbxItem; 
        }
        private DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
    }
}
