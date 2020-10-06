// ///////////////////////////////////////////////////////////
// Company:............. J.H. Kelly
// Department:.......... Virtual Design and Construction (VDC)
// Website:............. http://www.jhkelly.com
// Solution:............ Progress Bar Test 30
// Project:............. ProgressBarTest30
// File:................ MainWindowViewModel.cs
// Last Code Cleanup:... 08/25/2020 @ 2:51 PM Using ReSharper
// Review Comment:...... // ✓✓ 08/25/2020 - Review Comment:
// ///////////////////////////////////////////////////////////

namespace ProgressBarTest30.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Threading;
    using GalaSoft.MvvmLight.CommandWpf;
    using ProgressBarTest30.Models;
    using ProgressBarTest30.Properties;
    using ProjectM.Business.Commands;
    using Telerik.Windows.Controls;

    internal class MainWindowViewModel : ViewModelBase
    {
        #region Fields (All)

        private double currentProgress = 12.1;

        private List<ValveModel> valveModels;

        #endregion

        #region Constructors (All)

        public MainWindowViewModel()
        {
            this.valveModels = new List<ValveModel>();

            for (var i = 0; i < 123; i++)
            {
                this.valveModels.Add(new ValveModel($"Model Number {i}"));
            }

            this.CommandCalibrate = new RelayCommand<RadProgressBar>(this.Calibrate);
        }

        #endregion

        #region Events (All)

        public new event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties (Non-Private)

        public ICommand CommandCalibrate { get; set; }

        public double CurrentProgress
        {
            get { return this.currentProgress; }
            set
            {
                this.currentProgress = value;
                this.OnPropertyChanged();
            }
        }

        #endregion

        #region Properties (Private)

        private int ValvesCalibrated { get; set; }

        #endregion

        #region Methods (Non-Private)

        private void Calibrate(RadProgressBar bar)
        {
            DoWork(bar).FireAndForgetSafeAsync();
        }

        private async Task DoWork(RadProgressBar bar)
        {
            await Task.Run(() =>
                            {

                                foreach (var valveModel in this.valveModels)
                                {
                                    // Calibrate Valve

                                    // Increment Property
                                    this.ValvesCalibrated++;

                                    if (ValvesCalibrated != 0)
                                    {
                                        //This line just slows things down so you can see it remove for production stuff
                                        System.Threading.Thread.Sleep(100);
                                       bar.Dispatcher.Invoke(() =>  bar.Value = 100.0 * ValvesCalibrated / this.valveModels.Count);
                                    }
                                }

                                MessageBox.Show($"A total of {this.ValvesCalibrated} out of {this.valveModels.Count} valve were calibrated", "Message Box");
                            });
        }

        [NotifyPropertyChangedInvocator]
        public new void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}