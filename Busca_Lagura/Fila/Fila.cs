namespace Busca_Lagura
{
	public class Fila
	{
		public Elemento Inicio { get; set; }
		public Elemento Fim { get; set; }		

		// CONSTRUTOR DA CLASSE FILA
		public Fila()
		{
			Inicio = null;
			Fim = null;			
		}

		/// <summary>
		/// COLOCA UM VERTICE NA FILA
		/// </summary>
		/// <param name="vertice"></param>
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

		/// <summary>
		/// RETORNA O PRIMEIRO VERTICE DA FILA
		/// </summary>
		/// <returns></returns>
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

		/// <summary>
		/// VERIFICA SE A FILA ESTÁ VAZIA
		/// </summary>
		/// <returns></returns>
		public bool Vazio()
		{
			return (Inicio == null);
		}

		/// <summary>
		/// FUNÇÃO PARA REMOVER O PRIMIRO VERTICE DA FILA
		/// </summary>
		public void RemoverFila()
		{
			if(Inicio != null)
			{
				Inicio = Inicio.Proximo;

				if (Inicio == null)
					Fim = null;
			}
			
		}


	}
}
