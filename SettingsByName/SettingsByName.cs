/* Figured how to get and set appliction settings by using the Control.Name property. 
 */

using SettingsByName.Properties;
using System;
using System.Configuration;
using System.Linq;
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
            foreach (var c in panel1.Controls)
            {
                var control = c as Control;
                if (control != null)
                {
                    var setting = Settings.Default[control.Name];
                    if (control is TextBox)
                    {
                        control.Text = setting.ToString();
                    }
                    else if (control is CheckBox)
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

        private void OnSettingsChange(object sender, SettingChangingEventArgs e)
        {
            //this.PersonName.Text = e.NewValue.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Settings.Default.PersonName = "Klaas";
        }

        private void SettingsByName_Load(object sender, EventArgs e)
        {
            Settings.Default.SettingChanging += this.OnSettingsChange;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var properties = typeof(Settings).GetProperties();
            panel2.Controls.Clear();

            var top = 0;
            foreach (var property in properties)
            {
                var pt = property.PropertyType;
                var name = property.Name;
                Object setting = null;

                try
                {
                    setting = Settings.Default[name];
                }
                catch
                {
                    // do nothing.
                }

                if (setting != null)
                {
                    if (pt == typeof(string))
                    {
                        var t = new TextBox();
                        t.Text = Settings.Default[property.Name].ToString();
                        t.Parent = panel2;
                        t.Top = top;
                        top += t.Height + 5;
                    }
                    else if (pt == typeof(bool))
                    {
                        var t = new CheckBox();
                        t.Checked = (bool)Settings.Default[property.Name];
                        t.Parent = panel2;
                        t.Top = top;
                        top += t.Height + 5;
                    }
                    else
                    {
                        throw new Exception("Unsupported type");
                    }
                }
            }
        }
    }
}
