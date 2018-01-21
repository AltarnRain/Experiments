using DataGridWithObjectData.Handlers;
using System.Windows.Forms;
using DataGridWithObjectData.Factories;
using DataGridWithObjectData.Properties;

namespace DataGridWithObjectData.Binder
{
    public class DataSettingBinder : IDataSettingBinder
    {
        private readonly IDataHandlerFactory dataHandlerFactory;
        
        public DataSettingBinder(IDataHandlerFactory dataHandlerFactory)
        {
            this.dataHandlerFactory = dataHandlerFactory;            
        }

        public IDataHandler<T> Bind<T>(string settingName, DataGridView dataGrid)
        {
            var handler = this.dataHandlerFactory.Create<T>(Settings.Default[settingName].ToString());
            var bindingSource = new BindingSource();

            bindingSource.DataSource = handler.GetData();
            dataGrid.DataSource = bindingSource;
            dataGrid.AutoGenerateColumns = true;
            dataGrid.AutoSize = true;
            dataGrid.DataSource = bindingSource;
            return handler;
        }
    }
}
