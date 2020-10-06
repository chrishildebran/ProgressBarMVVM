namespace Main.Properties
{
    using System;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class AspRequiredAttributeAttribute : Attribute
    {
        #region Constructors (All)

        public AspRequiredAttributeAttribute([NotNull] string attribute)
        {
            this.Attribute = attribute;
        }

        #endregion

        #region Properties (Non-Private)

        [NotNull]
        public string Attribute { get; }

        #endregion
    }
}