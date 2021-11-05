using Mono.Reflection;

namespace Task2
{
    public static class ObjectExtensions
    {
        public static void SetReadOnlyProperty(this object obj, string propertyName, object newValue)
        {
            var property = obj.GetType().GetProperty(propertyName);
            if (property == null)
                throw new CustomArgumentNullException($"The property with name {propertyName} was not found.");
            var backingField = property.GetBackingField();
            backingField.SetValue(obj, newValue);
        }

        public static void SetReadOnlyField(this object obj, string filedName, object newValue)
        {
            var field = obj.GetType().GetField(filedName);
            if (field == null)
                throw new CustomArgumentNullException($"The field with name {filedName} was not found.");
            field.SetValue(obj, newValue);
        }
    }
}
