using System;
using JetBrains.Annotations;

namespace Assets.Scripts.GameManager.GameSystem.Attributes
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Field)]
    public sealed class InstallerAttribute : Attribute
    {
    }
}