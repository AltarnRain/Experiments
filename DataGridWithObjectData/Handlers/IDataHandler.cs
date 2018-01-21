using System.ComponentModel;

namespace DataGridWithObjectData.Handlers
{
    public interface IDataHandler<T>
    {
        BindingList<T> Add(T data);
        BindingList<T> Remove(T data);
        BindingList<T> GetData();
        string GetStringData();
    }
}