using MCR.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCR.views
{
    public class BaseForm : Form, MainThreadView
    {
        public void invokeOnMainThread(MethodInvoker methodInvoker)
        {
            this.Invoke(methodInvoker);
        }

        public T invokeOnMainThread<T>(Func<T> methodInvoker)
        {
            return (T)this.Invoke(methodInvoker);
        }
    }

    public class BaseUserControl : UserControl, MainThreadView
    {
        public void invokeOnMainThread(MethodInvoker methodInvoker)
        {
            this.Invoke(methodInvoker);
        }

        public T invokeOnMainThread<T>(Func<T> methodInvoker)
        {
            return (T)this.Invoke(methodInvoker);
        }
    }

    public interface MainThreadView
    {
        void invokeOnMainThread(MethodInvoker methodInvoker);
        T invokeOnMainThread<T>(Func<T> methodInvoker);
    }
    
}
