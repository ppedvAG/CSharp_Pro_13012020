using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HalloRefections
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"C:\Users\ar2\source\repos\ppedvAG\CSharp_Pro_13012020\HalloRefections\MachtZeug\bin\Debug\MachtZeug.dll";

            Assembly ass = Assembly.LoadFrom(path);
            foreach (var item in ass.GetTypes())
            {
                Console.WriteLine(item.FullName);
            }

            Type typeDerClass1 = ass.GetType("MachtZeug.Class1");
            Console.WriteLine(string.Join(", ", typeDerClass1.GetMembers().Select(x => x.Name)));

            object instance = Activator.CreateInstance(typeDerClass1);
            MethodInfo mInfo = typeDerClass1.GetMethod("SageHallo");
            mInfo.Invoke(instance, null);

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
