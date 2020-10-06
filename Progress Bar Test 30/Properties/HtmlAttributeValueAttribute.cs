namespace ProgressBarTest30.Properties
{
    using System;

    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class HtmlAttributeValueAttribute : Attribute
    {
        #region Constructors (All)

        public HtmlAttributeValueAttribute([NotNull] string name)
        {
            this.Name = name;
        }

        #endregion

        #region Properties (Non-Private)

        [NotNull]
        public string Name { get; }

        #endregion
    }
}