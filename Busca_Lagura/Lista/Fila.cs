using Busca_Lagura.Grafo;

namespace Busca_Lagura.Lista
{
	public class Fila
	{
		public Elemento Inicio { get; set; }
		public Elemento Fim { get; set; }
		public int QtdAtendidos { get; set; }

		public Fila()
		{
			Inicio = null;
			Fim = null;
			QtdAtendidos = 0;
		}

		public void ColocarFila(Vertice vertice)
		{
			Elemento novo = new Elemento
			{
				Vertice = vertice,
				Proximo = null
			};

			if (Fim != null)
				Fim.Proximo = novo;
			else
				Inicio = novo;

			Fim = novo;			
		}

		public Vertice BuscaPrimeiro()
		{	
			if (Inicio != null)
			{
				Elemento retorno = Inicio;
				Inicio = Inicio.Proximo;

				if (Inicio == null)
					Fim = null;

				return retorno.Vertice;
			}

			return null;
		}

	}
}
