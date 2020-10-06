namespace ProgressBarTest30.Properties
{
    using System;

    [AttributeUsage(AttributeTargets.Property)]
    public sealed class AspTypePropertyAttribute : Attribute
    {
        #region Constructors (All)

        public AspTypePropertyAttribute(bool createConstructorReferences)
        {
            this.CreateConstructorReferences = createConstructorReferences;
        }

        #endregion

        #region Properties (Non-Private)

        public bool CreateConstructorReferences { get; }

        #endregion
    }
}