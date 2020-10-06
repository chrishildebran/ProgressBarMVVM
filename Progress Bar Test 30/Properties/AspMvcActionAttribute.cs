namespace ProgressBarTest30.Properties
{
    using System;

    /// <summary>
    ///     ASP.NET MVC attribute. If applied to a parameter, indicates that the parameter
    ///     is an MVC action. If applied to a method, the MVC action name is calculated
    ///     implicitly from the context. Use this attribute for custom wrappers similar to
    ///     <c>System.Web.Mvc.Html.ChildActionExtensions.RenderAction(HtmlHelper, String)</c>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Method | AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class AspMvcActionAttribute : Attribute
    {
        #region Constructors (All)

        public AspMvcActionAttribute()
        {
        }

        public AspMvcActionAttribute([NotNull] string anonymousProperty)
        {
            this.AnonymousProperty = anonymousProperty;
        }

        #endregion

        #region Properties (Non-Private)

        [CanBeNull]
        public string AnonymousProperty { get; }

        #endregion
    }
}