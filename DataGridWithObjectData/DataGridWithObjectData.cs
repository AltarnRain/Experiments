/* An experimental program that uses a BindList as a Datasource linked to a DataGrid.
 * I'm storing a serialized string an in application settings to see if it is possible to serialize and deserialize data.
 * Guess what... it worked. 
 * OI
 */

using DataGridWithObjectData.Binder;
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

               
        private readonly IViewFactory viewFactory;
        private readonly IDataSettingBinder dataSettingBinder;

        public DataGridWithObjectData(IDataSettingBinder dataSettingBinder)
        {
            InitializeComponent();
            this.dataSettingBinder = dataSettingBinder;
        }

        private void DataGridWithObjectData_Load(object sender, EventArgs e)
        {            
     
        }

        private void Add_Click(object sender, EventArgs e)
        {
            //this.dataRowHandler.Add(new Data());
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            var listItem = DataGrid.CurrentRow.DataBoundItem as Data;
            //this.dataRowHandler.Remove(listItem);
        }
        
        private void Save_Click(object sender, EventArgs e)
        {
            //Settings.Default.Data = this.dataRowHandler.GetStringData();
            Settings.Default.Save();
        }
    }
}
