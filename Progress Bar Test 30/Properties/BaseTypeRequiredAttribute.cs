namespace ProgressBarTest30.Properties
{
    using System;

    /// <summary>
    ///     When applied to a target attribute, specifies a requirement for any type marked
    ///     with the target attribute to implement or inherit specific type or types.
    /// </summary>
    /// <example>
    ///     <code>
    /// [BaseTypeRequired(typeof(IComponent)] // Specify requirement
    /// class ComponentAttribute : Attribute { }
    /// 
    /// [Component] // ComponentAttribute requires implementing IComponent interface
    /// class MyComponent : IComponent { }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    [BaseTypeRequired(typeof(Attribute))]
    public sealed class BaseTypeRequiredAttribute : Attribute
    {
        #region Constructors (All)

        public BaseTypeRequiredAttribute([NotNull] Type baseType)
        {
            this.BaseType = baseType;
        }

        #endregion

        #region Properties (Non-Private)

        [NotNull]
        public Type BaseType { get; }

        #endregion
    }
}