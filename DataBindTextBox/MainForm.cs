using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBindTextBox
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public Model model = new Model();

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.textBox1.DataBindings.Add("Text",
                                this.model,
                                "Name",
                                false,
                                DataSourceUpdateMode.OnPropertyChanged);

            this.checkBox1.DataBindings.Add("Checked",
                             this.model,
                             "Checked",
                             false,
                             DataSourceUpdateMode.OnPropertyChanged);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.model.Name);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.model.Name = "Pet";
            this.model.Checked = true;
        }
    }


}
