using Ninject;
using System.Windows.Forms;

namespace Ninjection.Factories
{
    public class ViewFactory
    {
        private readonly IKernel kernel;

        public ViewFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public T Create<T>()
            where T : Form
        {
            return kernel.Get<T>();
        }
    }
}
