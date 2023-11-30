using System;
using JetBrains.Annotations;

namespace Assets.Scripts.GameManager.DI
{
    [MeansImplicitUse]
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
    public sealed class InjectAttribute : Attribute
    {
    }
}