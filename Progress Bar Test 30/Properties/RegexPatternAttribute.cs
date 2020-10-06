namespace ProgressBarTest30.Properties
{
    using System;

    /// <summary>
    ///     Indicates that the marked parameter is a regular expression pattern.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class RegexPatternAttribute : Attribute
    {
    }
}