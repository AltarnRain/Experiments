using DataGridWithObjectData.Providers;
using System.ComponentModel;

namespace DataGridWithObjectData.Handlers
{
    public class DataHandler<T> : IDataHandler<T>
    {
        private readonly IDataProvider<T> dataProvider;

        private BindingList<T> bindingList = new BindingList<T>();

        public DataHandler(IDataProvider<T> dataProvider, string data)
        {
            this.dataProvider = dataProvider;
            this.bindingList = dataProvider.GetData(data);
        }

        public BindingList<T> Add(T data)
        {
            this.bindingList.Add(data);
            return this.bindingList;
        }

        public BindingList<T> GetData()
        {
            return bindingList;
        }

        public string GetStringData()
        {
            return this.dataProvider.GetData(this.bindingList);
        }

        public BindingList<T> Remove(T data)
        {
            this.bindingList.Remove(data);
            return this.bindingList;
        }
    }
}
