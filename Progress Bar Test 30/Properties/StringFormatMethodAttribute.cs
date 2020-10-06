namespace ProgressBarTest30.Properties
{
    using System;

    /// <summary>
    ///     Indicates that the marked method builds string by the format pattern and (optional) arguments.
    ///     The parameter, which contains the format string, should be given in constructor. The format string
    ///     should be in <see cref="string.Format(IFormatProvider,string,object[])" />-like form.
    /// </summary>
    /// <example>
    ///     <code>
    /// [StringFormatMethod("message")]
    /// void ShowError(string message, params object[] args) { /* do something */ }
    /// 
    /// void Foo() {
    ///   ShowError("Failed: {0}"); // Warning: Non-existing argument in format string
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Delegate)]
    public sealed class StringFormatMethodAttribute : Attribute
    {
        #region Constructors (All)

        /// <param name="formatParameterName">
        ///     Specifies which parameter of an annotated method should be treated as the format string
        /// </param>
        public StringFormatMethodAttribute([NotNull] string formatParameterName)
        {
            this.FormatParameterName = formatParameterName;
        }

        #endregion

        #region Properties (Non-Private)

        [NotNull]
        public string FormatParameterName { get; }

        #endregion
    }
}