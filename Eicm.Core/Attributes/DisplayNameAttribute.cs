using System;

namespace Eicm.Core.Attributes
{
    public sealed class DisplayNameAttribute : Attribute
    {
        public DisplayNameAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
