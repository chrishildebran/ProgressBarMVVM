namespace Main.Properties
{
    using System;

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class RazorPageBaseTypeAttribute : Attribute
    {
        #region Constructors (All)

        public RazorPageBaseTypeAttribute([NotNull] string baseType)
        {
            this.BaseType = baseType;
        }

        public RazorPageBaseTypeAttribute([NotNull] string baseType, string pageName)
        {
            this.BaseType = baseType;
            this.PageName = pageName;
        }

        #endregion

        #region Properties (Non-Private)

        [NotNull]
        public string BaseType { get; }

        [CanBeNull]
        public string PageName { get; }

        #endregion
    }
}