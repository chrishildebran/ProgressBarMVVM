namespace ProgressBarTest30.Properties
{
    using System;

    /// <summary>
    ///     Indicates that a parameter is a path to a file or a folder within a web project.
    ///     Path can be relative or absolute, starting from web root (~).
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class PathReferenceAttribute : Attribute
    {
        #region Constructors (All)

        public PathReferenceAttribute()
        {
        }

        public PathReferenceAttribute([NotNull] [PathReference] string basePath)
        {
            this.BasePath = basePath;
        }

        #endregion

        #region Properties (Non-Private)

        [CanBeNull]
        public string BasePath { get; }

        #endregion
    }
}