using System.ComponentModel;

namespace DataGridWithObjectData.Providers
{
    public interface IDataProvider
    {
        BindingList<T> GetData<T>(string data);

        string GetData<T>(BindingList<T> bindingList);
    }
}