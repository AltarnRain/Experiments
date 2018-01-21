/* An experimental program that uses a BindList as a Datasource linked to a DataGrid.
 * I'm storing a serialized string an in application settings to see if it is possible to serialize and deserialize data.
 * Guess what... it worked. 
 * OI
 */

using DataGridWithObjectData.Factories;
using DataGridWithObjectData.Handlers;
using DataGridWithObjectData.Properties;
using DataGridWithObjectData.Providers;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DataGridWithObjectData
{
    public partial class DataGridWithObjectData : Form
    {

        private BindingSource bindingSource = new BindingSource();        
        private readonly IViewFactory viewFactory;
        private readonly IDataHandlerFactory dataHandlerFactory;
        private IDataHandler<Data> dataRowHandler;

        public DataGridWithObjectData(IViewFactory viewFactory, IDataHandlerFactory dataHandlerFactory)
        {
            InitializeComponent();
            this.viewFactory = viewFactory;
            this.dataHandlerFactory = dataHandlerFactory;

            this.dataRowHandler = this.dataHandlerFactory.Create<Data>(Settings.Default.Data);
        }

        private void DataGridWithObjectData_Load(object sender, EventArgs e)
        {            
            bindingSource.DataSource = dataRowHandler.GetData();
            DataGrid.AutoGenerateColumns = true;
            DataGrid.AutoSize = true;
            DataGrid.DataSource = bindingSource;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            this.dataRowHandler.Add(new Data());
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            var listItem = DataGrid.CurrentRow.DataBoundItem as Data;
            this.dataRowHandler.Remove(listItem);
        }
        
        private void Save_Click(object sender, EventArgs e)
        {
            Settings.Default.Data = this.dataRowHandler.GetStringData();
            Settings.Default.Save();
        }
    }
}
