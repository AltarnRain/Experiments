using DataGridWithObjectData.Factories;
using DataGridWithObjectData.Handlers;
using DataGridWithObjectData.Providers;
using Ninject.Modules;

namespace DataGridWithObjectData
{
    public class Modules : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<IViewFactory>().To<ViewFactory>().InSingletonScope();
            Kernel.Bind<IDataHandlerFactory>().To<DataHandlerFactory>().InSingletonScope();
            Kernel.Bind<IDataProvider>().To<DataProvider>().InSingletonScope();

            // Bind to an interface that employs a generic.
            Kernel.Bind(typeof(IDataHandler<>)).To(typeof(DataHandler<>));
        }
    }
}
