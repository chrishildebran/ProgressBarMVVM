namespace ProgressBarTest30.Properties
{
    using System;

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class RazorInjectionAttribute : Attribute
    {
        #region Constructors (All)

        public RazorInjectionAttribute([NotNull] string type, [NotNull] string fieldName)
        {
            this.Type      = type;
            this.FieldName = fieldName;
        }

        #endregion

        #region Properties (Non-Private)

        [NotNull]
        public string FieldName { get; }

        [NotNull]
        public string Type { get; }

        #endregion
    }
}