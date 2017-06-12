using System;

namespace Eicm.Core.Attributes
{
    public sealed class ParentIdAttribute : Attribute
    {
        public ParentIdAttribute(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}
