/* An experimental program that uses a BindList as a Datasource linked to a DataGrid.
 * I'm storing a serialized string an in application settings to see if it is possible to serialize and deserialize data.
 * Guess what... it worked. 
 * OI
 */

using DataGridWithObjectData.Properties;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DataGridWithObjectData
{
    public partial class DataGridWithObjectData : Form
    {

        private BindingSource bindingSource = new BindingSource();
        private BindingList<Data> lijst = new BindingList<Data>();

        public DataGridWithObjectData()
        {
            InitializeComponent();
        }

        private void DataGridWithObjectData_Load(object sender, EventArgs e)
        {
            if (Settings.Default.Data == string.Empty)
            {
                // Add some test data
                lijst.Add(new Data { Name = "Piet", Age = 39 });
                lijst.Add(new Data { Name = "Klaas", Age = 35 });
                lijst.Add(new Data { Name = "Joost", Age = 12 });
            }
            else
            {
                lijst = Newtonsoft.Json.JsonConvert.DeserializeObject<BindingList<Data>>(Settings.Default.Data);
            }

            bindingSource.DataSource = lijst;

            DataGrid.AutoGenerateColumns = true;
            DataGrid.AutoSize = true;
            DataGrid.DataSource = bindingSource;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            this.lijst.Add(new Data());
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            var listItem = DataGrid.CurrentRow.DataBoundItem as Data;
            this.lijst.Remove(listItem);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Save_Click(object sender, EventArgs e)
        {
            Settings.Default.Data = Newtonsoft.Json.JsonConvert.SerializeObject(lijst);
            Settings.Default.Save();
        }
    }
}
