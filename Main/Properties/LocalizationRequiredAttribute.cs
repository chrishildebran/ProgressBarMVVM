namespace Main.Properties
{
    using System;

    /// <summary>
    ///     Indicates whether the marked element should be localized.
    /// </summary>
    /// <example>
    ///     <code>
    /// [LocalizationRequiredAttribute(true)]
    /// class Foo {
    ///   string str = "my string"; // Warning: Localizable string
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.All)]
    public sealed class LocalizationRequiredAttribute : Attribute
    {
        #region Constructors (All)

        public LocalizationRequiredAttribute() : this(true)
        {
        }

        public LocalizationRequiredAttribute(bool required)
        {
            this.Required = required;
        }

        #endregion

        #region Properties (Non-Private)

        public bool Required { get; }

        #endregion
    }
}