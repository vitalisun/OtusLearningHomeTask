using System;
using JetBrains.Annotations;

namespace Assets.Scripts.DI
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class InjectAttribute : Attribute
    {
    }
}