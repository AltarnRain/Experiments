using System.ComponentModel;

namespace DataGridWithObjectData.Providers
{
    public class DataProvider<T> : IDataProvider<T>
    {
        public BindingList<T> GetData(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<BindingList<T>>(data);
        }

        public string GetData(BindingList<T> bindingList)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(bindingList);
        }
    }
}
