using System;
using System.Data.Common;

namespace es3_26_09_23
{
	internal class Starter
	{
		static void Main()
		{
			using(Esempio e0 = new Esempio("num 0")) { }
			Console.WriteLine("0: Con il blocco using passa dal metodo Dispose.\n");

			Esempio e1 = new Esempio("num 1");
			e1.Dispose();
			Console.WriteLine("1: Con il metodo Dispose() passa dal metodo virtual Dispose(bool disposing) con parametro true.\n");

			Esempio e2 = new Esempio("num 2");
			e2 = null;
			Console.WriteLine("2: Impostando l'oggetto a 'null' e aspettando un tempo indefinito,\n Garbage Collector userà il metodo finalizer(prima conosciuto come distruttore) ~Class \n");

			Esempio e3 = new Esempio("num 3");
			e1= e3 = null;
			GC.Collect();
			Console.WriteLine("3: Impostando l'oggetto a 'null' e usando il metodo GC.Collect(),\n Garbage Collector si avvierà una volta senza aspettare\n");
		}
	}
}
