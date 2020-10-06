namespace Main.Properties
{
    using System;

    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = true)]
    public sealed class AspMvcMasterLocationFormatAttribute : Attribute
    {
        #region Constructors (All)

        public AspMvcMasterLocationFormatAttribute([NotNull] string format)
        {
            this.Format = format;
        }

        #endregion

        #region Properties (Non-Private)

        [NotNull]
        public string Format { get; }

        #endregion
    }
}