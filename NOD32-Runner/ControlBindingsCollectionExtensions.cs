using System.Windows.Forms;
using KoKo.Property;

namespace NOD32_Runner
{
    public static class ControlBindingsCollectionExtensions
    {
        public static Binding Add(this ControlBindingsCollection bindings, string controlPropertyName, Property kokoProperty)
        {
            return bindings.Add(controlPropertyName, kokoProperty, nameof(Property<object>.Value));
        }
    }
}