using System.Windows.Forms;
using CoCo.Property;

namespace NOD32_Runner
{
    public static class ControlBindingsCollectionExtensions
    {
        public static Binding Add(this ControlBindingsCollection bindings, string controlPropertyName, Property cocoProperty)
        {
            return bindings.Add(controlPropertyName, cocoProperty, nameof(Property<object>.Value));
        }
    }
}