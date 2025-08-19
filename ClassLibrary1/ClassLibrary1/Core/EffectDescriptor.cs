using System;
using ClassLibrary1.Abstractions;

namespace ClassLibrary1.Core
{
    /// <summary>
    /// A concrete effect coupled with an optional value to apply.
    /// </summary>
    public sealed class EffectDescriptor
    {
        public EffectDescriptor(IImageEffect effect, object? parameterValue)
        {
            Effect = effect;
            ParameterValue = parameterValue;
        }

        public IImageEffect Effect { get; }
        public object? ParameterValue { get; }
    }
}


