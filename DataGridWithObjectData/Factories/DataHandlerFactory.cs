using DataGridWithObjectData.Handlers;
using Ninject;
using Ninject.Parameters;

namespace DataGridWithObjectData.Factories
{
    public class DataHandlerFactory : IDataHandlerFactory
    {
        public IKernel Kernel { get; }

        public DataHandlerFactory(IKernel kernel)
        {
            Kernel = kernel;
        }

        public IDataHandler<T> Create<T>(string data)
        {
            
            var handler = this.Kernel.TryGet<IDataHandler<T>>(new ConstructorArgument("data", data));
            return handler;
        }
    }
}
