namespace Main.Properties
{
    using System;

    /// <summary>
    ///     ASP.NET MVC attribute. Indicates that the marked parameter is an MVC area.
    ///     Use this attribute for custom wrappers similar to
    ///     <c>System.Web.Mvc.Html.ChildActionExtensions.RenderAction(HtmlHelper, String)</c>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field | AttributeTargets.Property)]
    public sealed class AspMvcAreaAttribute : Attribute
    {
        #region Constructors (All)

        public AspMvcAreaAttribute()
        {
        }

        public AspMvcAreaAttribute([NotNull] string anonymousProperty)
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