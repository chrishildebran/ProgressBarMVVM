namespace Main
{
    using System;
    using System.ServiceModel.Dispatcher;
    using System.Threading.Tasks;

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
