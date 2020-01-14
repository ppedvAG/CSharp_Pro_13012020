using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleBooksClient
{
    delegate void EinfacheDelegate();
    delegate void DelegateMitParameter(string text);
    delegate long CalcDelegate(int a, int b);

    class HalloDelegate
    {
        public HalloDelegate()
        {
            EinfacheDelegate meineDele = EinfacheMethode;
            Action meineDeleAlsAction = EinfacheMethode;
            Action meineDeleAlsAction2 = delegate () { Console.WriteLine("Hallo"); };
            Action meineDeleAlsAction3 = () => { Console.WriteLine("Hallo"); };
            Action meineDeleAlsAction4 = () => Console.WriteLine("Hallo");

            DelegateMitParameter meinDeleMitPara = MethodeMitPara;
            Action<string> meinDeleMitParaAlsAction = MethodeMitPara;
            Action<string> meinDeleMitParaAlsAction2 = (string x) => { Console.WriteLine(x); };
            Action<string> meinDeleMitParaAlsAction3 = (x) => Console.WriteLine(x);
            Action<string> meinDeleMitParaAlsAction4 = x => Console.WriteLine(x);

            CalcDelegate calc = Minus;
            Func<int, int, long> calcAlsFunc = Summe;
            Func<int, int, long> calcAlsFunc2 = (x, y) => { return x - y; };
            Func<int, int, long> calcAlsFunc3 = (x, y) =>  x - y;

            List<string> texte = new List<string>();
            texte.Where(x => x == "Hund");
            texte.Where(Filter);
        }

        private bool Filter(string arg)
        {
            if (arg == "Hund")
                return true;
            else
                return false;
        }

        private long Minus(int a, int b)
        {
            return a - b;
        }

        private long Summe(int a, int b)
        {
            return a + b;
        }

        private void MethodeMitPara(string text)
        {
            Console.WriteLine($"Hallo {text}");
        }

        public void EinfacheMethode()
        {
            System.Console.WriteLine("Hallo");
        }
    }
}
