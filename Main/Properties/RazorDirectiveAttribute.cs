namespace Main.Properties
{
    using System;

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class RazorDirectiveAttribute : Attribute
    {
        #region Constructors (All)

        public RazorDirectiveAttribute([NotNull] string directive)
        {
            this.Directive = directive;
        }

        #endregion

        #region Properties (Non-Private)

        [NotNull]
        public string Directive { get; }

        #endregion
    }
}