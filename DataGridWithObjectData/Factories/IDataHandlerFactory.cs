using DataGridWithObjectData.Handlers;
using Ninject;

namespace DataGridWithObjectData.Factories
{
    public interface IDataHandlerFactory
    {
        IKernel Kernel { get; }

        IDataHandler<T> Create<T>(string data);
    }
}