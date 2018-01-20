/* Figured how to get and set appliction settings by using the Control.Name property. 
 */

using SettingsByName.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SettingsByName
{
    public partial class SettingsByName : Form
    {
        public SettingsByName()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(var c in panel1.Controls)
            {
                var control = c as Control;
                if (control != null)
                {
                    var setting = Settings.Default[control.Name];
                    if (control is TextBox)
                    {
                        control.Text = setting.ToString();
                    } else if (control is CheckBox)
                    {
                        (control as CheckBox).Checked = (bool)Settings.Default[control.Name];
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var c in panel1.Controls)
            {
                var control = c as Control;
                if (control != null)
                {                   
                    if (control is TextBox)
                    {
                        Settings.Default[control.Name] = control.Text;
                    }
                    else if (control is CheckBox)
                    {
                        Settings.Default[control.Name] = ((CheckBox)control).Checked;
                    }
                }
            }

            Settings.Default.Save();
        }
    }
}
