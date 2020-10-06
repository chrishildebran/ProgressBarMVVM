namespace ProgressBarTest30.Properties
{
    using System;

    /// <summary>
    ///     Indicates the condition parameter of the assertion method. The method itself should be
    ///     marked by <see cref="AssertionMethodAttribute" /> attribute. The mandatory argument of
    ///     the attribute is the assertion type.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class AssertionConditionAttribute : Attribute
    {
        #region Constructors (All)

        public AssertionConditionAttribute(AssertionConditionType conditionType)
        {
            this.ConditionType = conditionType;
        }

        #endregion

        #region Properties (Non-Private)

        public AssertionConditionType ConditionType { get; }

        #endregion
    }
}