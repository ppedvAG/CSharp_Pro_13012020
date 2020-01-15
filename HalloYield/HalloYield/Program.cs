using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloYield
{
    class Program
    {
        private int myProperty;

        static void Main(string[] args)
        {
            Console.WriteLine("Hallo");

            foreach (var item in GetTage().ToList())
            {
                Console.WriteLine(item);
            }



            Hund hund = new Hund();

            Tier tier = hund;

            //casting + typrüfung
            if (tier is Hund)
            {
                Hund tierAlsHund = (Hund)tier;
            }

            //boxing
            Hund meinHund = tier as Hund;
            if (meinHund != null)
            {

            }

            //pattern.matching
            if (tier is Hund meinTierAlsHund)
            {
                meinTierAlsHund.Bellen();
            }

            var dings = GetTagUndKW();
            //dings.zahö



            Hund hund2 = new Hund();

            Console.WriteLine(hund2.MyProperty?.Name?.Length);


            Console.WriteLine("Ende");
            Console.ReadLine();
        }


        public int MyProperty { get => myProperty; set => myProperty = value; }

        public static IEnumerable<DateTime> GetTage()
        {
            yield return DateTime.Now;
            yield return DateTime.Now.AddDays(1);
            yield return DateTime.Now.AddDays(2);
        }

        public static (DateTime dt, int zahö) GetTagUndKW()
        {
            return (DateTime.Now, 17);
        }
    }

    public class Hund : Tier
    {
        public void Bellen()
        { }
        public Tier MyProperty { get; set; }
    }

    public class Tier
    {
        public void MachLaut()
        { }
        public string Name { get; set; }
    }
}
