using System.Windows.Forms;
using DataGridWithObjectData.Handlers;

namespace DataGridWithObjectData.Binder
{
    public interface IDataSettingBinder
    {
        IDataHandler<T> Bind<T>(string settingName, DataGridView dataGrid);
    }
}