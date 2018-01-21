using System.ComponentModel;

namespace DataGridWithObjectData.Providers
{
    public class DataProvider : IDataProvider
    {
        public BindingList<T> GetData<T>(string data)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<BindingList<T>>(data);
        }

        public string GetData<T>(BindingList<T> bindingList)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(bindingList);
        }
    }
}
