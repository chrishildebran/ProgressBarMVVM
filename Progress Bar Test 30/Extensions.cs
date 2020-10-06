using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressBarTest30
{
    using System.Collections.ObjectModel;
    using System.ServiceModel.Dispatcher;
    using System.Windows.Controls;
    using GalaSoft.MvvmLight.Messaging;

    public static class Extensions
    {
        public static async void FireAndForgetSafeAsync(this Task task, IErrorHandler handler = null)
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                handler?.HandleError(ex);
            }
        }
    }
}
