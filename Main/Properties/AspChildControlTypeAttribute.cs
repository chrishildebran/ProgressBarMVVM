namespace Main.Properties
{
    using System;

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public sealed class AspChildControlTypeAttribute : Attribute
    {
        #region Constructors (All)

        public AspChildControlTypeAttribute([NotNull] string tagName, [NotNull] Type controlType)
        {
            this.TagName     = tagName;
            this.ControlType = controlType;
        }

        #endregion

        #region Properties (Non-Private)

        [NotNull]
        public Type ControlType { get; }

        [NotNull]
        public string TagName { get; }

        #endregion
    }
}