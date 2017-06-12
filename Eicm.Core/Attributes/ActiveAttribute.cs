using System;

namespace Eicm.Core.Attributes
{
    public sealed class ActiveAttribute : Attribute
    {
        public ActiveAttribute(bool value)
        {
            Value = value;
        }

        public bool Value { get; }
    }
}
