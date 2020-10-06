namespace ProgressBarTest30.Properties
{
    using System;

    /// <summary>
    ///     This attribute is intended to mark publicly available API
    ///     which should not be removed and so is treated as used.
    /// </summary>
    [MeansImplicitUse(ImplicitUseTargetFlags.WithMembers)]
    [AttributeUsage(AttributeTargets.All, Inherited = false)]
    public sealed class PublicAPIAttribute : Attribute
    {
        #region Constructors (All)

        public PublicAPIAttribute()
        {
        }

        public PublicAPIAttribute([NotNull] string comment)
        {
            this.Comment = comment;
        }

        #endregion

        #region Properties (Non-Private)

        [CanBeNull]
        public string Comment { get; }

        #endregion
    }
}