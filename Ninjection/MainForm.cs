using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ninjection
{
    public partial class MainForm : Form
    {
        private readonly Factories.ViewFactory viewFactory;

        public MainForm(Factories.ViewFactory viewFactory)
        {
            InitializeComponent();
            this.viewFactory = viewFactory;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var formResult = this.viewFactory.Create<SubForm>().ShowDialog();
        }
    }
}
