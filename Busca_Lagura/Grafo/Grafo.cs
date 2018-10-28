using System;


namespace Busca_Lagura
{
	public class Grafo
	{

		public Vertice Inicio { get; set; }
		public int QtdVertices { get; set; }

		// CONSTRUTOR DA CLASSE GRAFO
		public Grafo()
		{
			Inicio = null;
			QtdVertices = 0;
		}

		/// <summary>
		/// FUNÇÃO RESPONSAVEL EM EXIBIR O GRAFO NA TELA
		/// </summary>
		public void ExibirGrafo()
		{
			Vertice vertice = Inicio;
			Aresta aresta;

			Console.WriteLine("O grafo possui {0} vértices.", QtdVertices);

			while (vertice != null)
			{
				Console.Write("Cidade..: {0}\nGrau....: {1}\n", vertice.Cidade, vertice.Grau);
				Console.Write("Vértices: ");

				aresta = vertice.Adjacentes;
				while (aresta != null)
				{
					Console.Write("{0}, ", aresta.Destino);
					aresta = aresta.Proxima;
				}

				Console.WriteLine("\n========================================");
				vertice = vertice.Proximo;
			}
		}

		/// <summary>
		/// FUNÇÃO PARA VERIFICAR SE A CIDADE JÁ SE ENCONTRA CADASTRADA
		/// </summary>
		/// <param name="cidade"></param>
		/// <returns></returns>
		public bool VerificarCidade(string cidade)
		{
			Vertice vertice = Inicio;

			while ((vertice != null) 
				&& !(vertice.Cidade.Trim().ToLower().Equals(cidade.Trim().ToLower())))
				vertice = vertice.Proximo;

			return (vertice != null);
		}

		/// <summary>
		/// FUNÇÃO PARA INCLUIR UMA NOVA CIDADE NO GRAFO 
		/// </summary>
		/// <param name="cidade"></param>
		public void IncluirCidade(string cidade)
		{
			Vertice novo = new Vertice();

			novo.Cidade = cidade;
			novo.Proximo = Inicio;
			Inicio = novo;

			QtdVertices++;
		}

		/// <summary>
		/// FUNÇÃO PARA VERIFICA SE EXISTE CONEXÃO ENTRE DUAS CIDADES
		/// </summary>
		/// <param name="cidadeIn"></param>
		/// <param name="cidadeFim"></param>
		/// <returns></returns>
		public bool VerificarConexao(string cidadeIn, string cidadeFim)
		{
			Vertice vertice = Inicio;
			Aresta aresta;

			while (!vertice.Cidade.Trim().ToLower().Equals(cidadeIn.Trim().ToLower()))
				vertice = vertice.Proximo;

			aresta = vertice.Adjacentes;

			while ((aresta != null) 
				&& (!aresta.Destino.Trim().ToLower().Equals(cidadeFim.Trim().ToLower())))
				aresta = aresta.Proxima;

			return (aresta != null);
		}

		/// <summary>
		/// FUNÇÃO PARA INCLUI UMA CONEXAO ENTRE DOIS VERTICES EXISTENTES NO GRAFO
		/// </summary>
		/// <param name="cidadeIn"></param>
		/// <param name="cidadeFim"></param>
		public void IncluirConexao(string cidadeIn, string cidadeFim)
		{
			Vertice vertice = Inicio;
			Aresta nova = new Aresta();

			while (!vertice.Cidade.Trim().ToLower().Equals(cidadeIn.Trim().ToLower()))
			{
				vertice = vertice.Proximo;
			}

			vertice.Grau++;
			nova.Proxima = vertice.Adjacentes;
			vertice.Adjacentes = nova;
			nova.Destino = cidadeFim;

			nova = new Aresta();
			vertice = Inicio;

			while (!vertice.Cidade.Trim().ToLower().Equals(cidadeFim.Trim().ToLower()))
			{
				vertice = vertice.Proximo;
			}

			vertice.Grau++;
			nova.Proxima = vertice.Adjacentes;
			vertice.Adjacentes = nova;
			nova.Destino = cidadeIn;

		}

		/// <summary>
		/// FUNÇÃO PARA REMOVE UMA CIDADE DO GRAFO
		/// </summary>
		/// <param name="cidade"></param>
		public void RemoverCidade(string cidade)
		{
			Vertice vertice = Inicio, ant = null;

			while (vertice != null)
			{
				if (VerificarConexao(cidade, vertice.Cidade))
					RemoverConexao(cidade, vertice.Cidade);

				vertice = vertice.Proximo;
			}

			vertice = Inicio;

			while (!vertice.Cidade.Trim().ToLower().Equals(cidade.Trim().ToLower()))
			{
				ant = vertice;
				vertice = vertice.Proximo;
			}

			QtdVertices--;

			if (ant == null)
				Inicio = Inicio.Proximo;
			else
				ant.Proximo = vertice.Proximo;
		}

		/// <summary>
		/// FUNÇÃO PARA REMOVE UMA CONEXAO ENTRE DOIS VERTICES DO GRAFO
		/// </summary>
		/// <param name="cidadeIn"></param>
		/// <param name="cidadeFim"></param>
		public void RemoverConexao(string cidadeIn, string cidadeFim)
		{
			Vertice vertice = Inicio;
			Aresta aresta, ant;

			while (!vertice.Cidade.Trim().ToLower().Equals(cidadeIn.Trim().ToLower()))
				vertice = vertice.Proximo;

			vertice.Grau--;

			aresta = vertice.Adjacentes;
			ant = null;

			while (!aresta.Destino.Trim().ToLower().Equals(cidadeFim.Trim().ToLower()))
			{
				ant = aresta;
				aresta = aresta.Proxima;
			}

			if (ant == null)
				vertice.Adjacentes = aresta.Proxima;
			else
				ant.Proxima = aresta.Proxima;


			/* segunda cidade */
			vertice = Inicio;

			while (!vertice.Cidade.Trim().ToLower().Equals(cidadeFim.Trim().ToLower()))
				vertice = vertice.Proximo;

			vertice.Grau--;

			aresta = vertice.Adjacentes;
			ant = null;

			while (!aresta.Destino.Trim().ToLower().Equals(cidadeIn.Trim().ToLower()))
			{
				ant = aresta;
				aresta = aresta.Proxima;
			}

			if (ant == null)
				vertice.Adjacentes = aresta.Proxima;
			else
				ant.Proxima = aresta.Proxima;		
				
		}

		/// <summary>
		/// FUNÇÃO PARA ZERA O GRAFO 
		/// </summary>
		public void ReiniciarGrafo()
		{
			Inicio = null;
			QtdVertices = 0;
		}

		/// <summary>
		/// REALIZA A BUSCA EM LARGURA NO GRAFO
		/// </summary>
		/// <param name="cidade"></param>
		/// <returns></returns>
		public bool BuscaLargura(string cidade)
		{
			DesmarcarVertices();
			Fila fila = new Fila();

			Vertice verticeInicial = Inicio;
			verticeInicial.Status = true;
			fila.ColocarFila(verticeInicial);

			while (!fila.Vazio())
			{
				bool encontrou;
				Vertice vertice = fila.BuscaPrimeiro();

				while(vertice != null && vertice.Proximo != null)
				{
					Vertice aux = vertice.Proximo;
					Aresta auxA = vertice.Adjacentes;

					if (!aux.Status)
					{
						encontrou = ExplorarAresta(auxA, cidade);
						if (encontrou)
							return encontrou;
											
						aux.Status = true;
						fila.ColocarFila(aux);

					}
					else
					{
						encontrou = ExplorarAresta(auxA, cidade);
						if (encontrou)
							return encontrou;
					}

					vertice = vertice.Proximo;
				}
				fila.RemoverFila();
			}

			return false;

		}

		/// <summary>
		/// FUNÇÃO PARA DESMARCAR TODOS OS VERTICES DO GRAFO, PARA A BUSCA EM LARGURA
		/// </summary>
		public void DesmarcarVertices()
		{
			Vertice vertice = Inicio;

			while (vertice != null)
			{
				vertice.Status = false;
				vertice = vertice.Proximo;
			}

		}

		/// <summary>
		/// FUNÇÃO PARA EXPLORAR AS ARESTAS DE UM VERTICE
		/// </summary>
		/// <param name="aresta"></param>
		/// <param name="cidade"></param>
		/// <returns></returns>
		public bool ExplorarAresta(Aresta aresta, string cidade)
		{
			while (aresta != null)
			{
				if (aresta.Destino.Trim().ToLower().Equals(cidade.Trim().ToLower()))
				{
					return true;
				}

				aresta = aresta.Proxima;
			}

			return false;
		}
	}
}
