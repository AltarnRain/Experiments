using System.ComponentModel;

namespace DataGridWithObjectData.Providers
{
    public interface IDataProvider<T>
    {
        BindingList<T> GetData(string data);

        string GetData(BindingList<T> bindingList);
    }
}