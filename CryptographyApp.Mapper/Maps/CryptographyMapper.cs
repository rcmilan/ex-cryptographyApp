using CryptographyApp.Mapper.CryptographyAttributes;
using System.Reflection;
using System.Reflection.Emit;

namespace CryptographyApp.Mapper.Maps
{
    internal class CryptographyMapper : ICryptographyMapper
    {
        private const string ASSEMBLY_NAME = "CryptographyAppAssembly";
        private const string METHOD_NAME = "MapMethod";
        private const string TYPEBUILDER_NAME = "MyCryptographyMapper";

        public TResult Map<TSource, TResult>(in TSource source)
            where TSource : class
            where TResult : class
        {
            var map = GetMapMethod<TSource, TResult>();

            return (TResult)map.Invoke(null, new[] { source })!;
        }

        private static MethodInfo GetMapMethod<TSource, TResult>()
            where TSource : class
            where TResult : class
        {
            var aName = new AssemblyName(ASSEMBLY_NAME);
            var ab = AssemblyBuilder.DefineDynamicAssembly(aName, AssemblyBuilderAccess.Run);
            var mb = ab.DefineDynamicModule(aName.Name!);

            var typeBuilder = mb.DefineType(TYPEBUILDER_NAME, TypeAttributes.NotPublic);

            var fromType = typeof(TSource);
            var toType = typeof(TResult);

            var methodBuilder = typeBuilder
                .DefineMethod(
                    METHOD_NAME,
                    MethodAttributes.Public | MethodAttributes.Static,
                    toType,
                    new[] { fromType }
                );

            var gen = methodBuilder.GetILGenerator();
            gen.Emit(OpCodes.Newobj, toType.GetConstructor(Type.EmptyTypes)!);

            foreach (var property in fromType.GetProperties())
            {
                var toProp = toType.GetProperty(property.Name);
                if (toProp == null)
                    continue;

                gen.Emit(OpCodes.Dup);
                gen.Emit(OpCodes.Ldarg_0);
                gen.Emit(OpCodes.Callvirt, property.GetMethod!);

                //var attr = (SensitiveInfoAttribute[])property.GetCustomAttributes(typeof(SensitiveInfoAttribute), false);

                //if (attr.Length > 0)
                //{
                //    // possui o attr SensitiveInfoAttribute
                //    // chama o setter + função de criptografia
                //}
                //else
                    gen.Emit(OpCodes.Callvirt, toProp.SetMethod!);
            }

            gen.Emit(OpCodes.Ret);

            var type = typeBuilder.CreateType();

            return type.GetMethod(METHOD_NAME, BindingFlags.Public | BindingFlags.Static, new[] { fromType })!;
        }
    }
}