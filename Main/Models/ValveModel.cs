// ///////////////////////////////////////////////////////////
// Company:............. J.H. Kelly
// Department:.......... Virtual Design and Construction (VDC)
// Website:............. http://www.jhkelly.com
// Solution:............ ProgressBarMVVM
// Project:............. Main
// File:................ ValveModel.cs
// Last Code Cleanup:... 10/06/2020 @ 1:51 PM Using ReSharper
// Review Comment:...... // ✓✓ 10/06/2020 - Review Comment:
// ///////////////////////////////////////////////////////////

namespace Main.Models
{
    internal class ValveModel
    {
        #region Constructors (All)

        public ValveModel(string model)
        {
            this.Model = model;
        }

        #endregion

        #region Properties (Non-Private)

        public string Model { get; set; }

        #endregion
    }
}