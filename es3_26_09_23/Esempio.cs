using System;

namespace es3_26_09_23
{
	internal class Esempio : IDisposable
	{

		private string _nome;
		private bool _disposed;

		public string Nome
		{
			get { return _nome; }
			set { _nome = value; }
		}

		public Esempio(string n = "nome")
		{
			Nome = n;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if(!_disposed)
			{
				if(disposing)
				{
					Console.WriteLine($"Oggetto {Nome} Eliminato");
					// rilascia le risorse gestite qui (qual'ora ci fossero)
				}
				// rilascia le risorse non gestite qui (qual'ora ci fossero)

				_disposed = true;
			}
		}

		public void Visualizza()
		{
			Console.WriteLine("Nome: " + _nome);
		}

		//auto run se passa per il garbage collector GC, il GC decide se e quando c'è bisogno di distruggere l'oggetto
		// forzabile con il metodo Collect (dopo aver impostasto l'oggetto a null)
		// se passa prima per Dispose che ha 'GC.SuppressFinalize(this);' allora non passa per il finalizer
		~Esempio() // finalizer (vecchio nome: distruttore)
		{
			Dispose(false);
			Console.WriteLine("Distruttore di " + Nome);
		}

	}
}
