namespace Main.Properties
{
    using System;

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public sealed class RazorImportNamespaceAttribute : Attribute
    {
        #region Constructors (All)

        public RazorImportNamespaceAttribute([NotNull] string name)
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