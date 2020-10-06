// ///////////////////////////////////////////////////////////
// Company:............. J.H. Kelly
// Department:.......... Virtual Design and Construction (VDC)
// Website:............. http://www.jhkelly.com
// Solution:............ Progress Bar Test 30
// Project:............. Progress Bar Test 30
// File:................ Annotations.cs
// Last Code Cleanup:... 08/25/2020 @ 2:20 PM Using ReSharper
// Review Comment:...... // ✓✓ 08/25/2020 - Review Comment:
// ///////////////////////////////////////////////////////////

// ReSharper disable InheritdocConsiderUsage

#pragma warning disable 1591

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable IntroduceOptionalParameters.Global
// ReSharper disable MemberCanBeProtected.Global
// ReSharper disable InconsistentNaming

namespace ProgressBarTest30.Properties
{
    using System;

    /// <summary>
    ///     Indicates that the value of the marked element could be <c>null</c> sometimes,
    ///     so checking for <c>null</c> is required before its usage.
    /// </summary>
    /// <example>
    ///     <code>
    /// [CanBeNull] object Test() => null;
    /// 
    /// void UseTest() {
    ///   var p = Test();
    ///   var s = p.ToString(); // Warning: Possible 'System.NullReferenceException'
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.Delegate | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.GenericParameter)]
    public sealed class CanBeNullAttribute : Attribute
    {
    }
}