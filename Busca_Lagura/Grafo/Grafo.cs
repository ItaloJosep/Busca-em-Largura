using System;


namespace Busca_Lagura
{
	public class Grafo
	{

		public Vertice Inicio { get; set; }
		public int QtdVertices { get; set; }

		public Grafo()
		{
			Inicio = null;
			QtdVertices = 0;
		}

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

				Console.WriteLine("====================================");
				vertice = vertice.Proximo;
			}
		}

		public bool VerificarCidade(string cidade)
		{
			Vertice vertice = Inicio;

			while ((vertice != null) 
				&& (vertice.Cidade.Trim().ToLower().Equals(cidade.Trim().ToLower())))
				vertice = vertice.Proximo;

			return (vertice != null);
		}

		public void IncluirCidade(string cidade)
		{
			Vertice novo = new Vertice();

			novo.Cidade = cidade;
			novo.Proximo = Inicio;
			Inicio = novo;

			QtdVertices++;
		}

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






	}
}
