// ///////////////////////////////////////////////////////////
// Company:............. J.H. Kelly
// Department:.......... Virtual Design and Construction (VDC)
// Website:............. http://www.jhkelly.com
// Solution:............ ProgressBarMVVM
// Project:............. Main
// File:................ MainWindowViewModel.cs
// Last Code Cleanup:... 10/06/2020 @ 11:28 AM Using ReSharper
// Review Comment:...... // ✓✓ 10/06/2020 - Review Comment:
// ///////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using Main.Models;
using Main.Properties;
using Telerik.Windows.Controls;

namespace Main.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        #region Constructors (All)

        public MainWindowViewModel()
        {
            this.valveModels = new List<ValveModel>();

            for (var i = 0; i < 123; i++) this.valveModels.Add(new ValveModel($"Model Number {i}"));

            this.CommandCalibrate = new RelayCommand<RadProgressBar>(this.Calibrate);
        }

        #endregion

        #region Properties (Private)

        private int ValvesCalibrated { get; set; }

        #endregion

        #region Events (All)

        public new event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Fields (All)

        private double currentProgress = 12.1;

        private readonly List<ValveModel> valveModels;

        #endregion

        #region Properties (Non-Private)

        public ICommand CommandCalibrate { get; set; }

        public double CurrentProgress
        {
            get => this.currentProgress;
            set
            {
                this.currentProgress = value;
                this.OnPropertyChanged();
            }
        }

        #endregion

        #region Methods (Non-Private)

        private void Calibrate(RadProgressBar bar)
        {
            this.DoWork(bar).FireAndForgetSafeAsync();
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

                    if (this.ValvesCalibrated != 0)
                    {
                        //This line just slows things down so you can see it remove for production stuff
                        Thread.Sleep(10);
                        bar.Dispatcher.Invoke(() => bar.Value = 100.0 * this.ValvesCalibrated / this.valveModels.Count);
                    }
                }

                MessageBox.Show(
                    $"A total of {this.ValvesCalibrated} out of {this.valveModels.Count} valve were calibrated",
                    "Message Box");
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