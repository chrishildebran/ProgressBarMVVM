namespace Main.Properties
{
    using System;

    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class HtmlElementAttributesAttribute : Attribute
    {
        #region Constructors (All)

        public HtmlElementAttributesAttribute()
        {
        }

        public HtmlElementAttributesAttribute([NotNull] string name)
        {
            this.Name = name;
        }

        #endregion

        #region Properties (Non-Private)

        [CanBeNull]
        public string Name { get; }

        #endregion
    }
}