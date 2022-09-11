using System.Reflection;

namespace FoodStoreApp.Helpers
{
    public class ClassHelpers
    {
        public static void ShowFieldsValues<T>(T yourInstance)
        {
            IEnumerable<FieldInfo> fields = yourInstance.GetType().GetTypeInfo().DeclaredFields;

            foreach (var field in fields.Where(x => !x.IsStatic))
            {
                Console.WriteLine("{0}={1}", field.Name, field.GetValue(yourInstance));
            }
        }
    }
}
