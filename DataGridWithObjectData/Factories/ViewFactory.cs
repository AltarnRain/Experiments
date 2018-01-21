using Ninject;

namespace DataGridWithObjectData.Factories
{
    public class ViewFactory : IViewFactory
    {
        private readonly IKernel kernel;

        public ViewFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public T Create<T>()
        {
            return this.kernel.Get<T>();
        }
    }
}
