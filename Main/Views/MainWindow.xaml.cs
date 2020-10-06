// ///////////////////////////////////////////////////////////
// Company:............. J.H. Kelly
// Department:.......... Virtual Design and Construction (VDC)
// Website:............. http://www.jhkelly.com
// Solution:............ Progress Bar Test 30
// Project:............. Progress Bar Test 30
// File:................ MainWindow.xaml.cs
// Last Code Cleanup:... 08/25/2020 @ 2:20 PM Using ReSharper
// Review Comment:...... // ✓✓ 08/25/2020 - Review Comment:
// ///////////////////////////////////////////////////////////

namespace Main.Views
{
    using System.Windows;
    using Main.ViewModels;

    public partial class MainWindow : Window
    {
        #region Constructors (All)

        public MainWindow()
        {
            this.InitializeComponent();

           this.DataContext = new MainWindowViewModel();
        }

        #endregion
    }
}