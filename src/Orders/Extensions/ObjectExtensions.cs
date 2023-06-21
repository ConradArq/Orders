using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoConrado.Extensions
{
    public static class ObjectExtensions
    {
        public static Object CopyPropertiesTo(this Object source, Object target)
        {
            var destProperties = target.GetType().GetProperties();

            foreach (var sourceProperty in source.GetType().GetProperties())
            {
                foreach (var destProperty in destProperties)
                {
                    if (destProperty.Name == sourceProperty.Name && destProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                    {
                        destProperty.SetValue(target, sourceProperty.GetValue(source, new object[] { }), new object[] { });
                        break;
                    }
                }
            }
            return target;
        }
    }
}