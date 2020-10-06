// ///////////////////////////////////////////////////////////
// Company:............. J.H. Kelly
// Department:.......... Virtual Design and Construction (VDC)
// Website:............. http://www.jhkelly.com
// Solution:............ Progress Bar For MVVM
// Project:............. Main
// File:................ MainWindow.xaml.cs
// Last Code Cleanup:... 10/06/2020 @ 11:15 AM Using ReSharper
// Review Comment:...... // ✓✓ 10/06/2020 - Review Comment:
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