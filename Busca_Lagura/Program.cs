using System;

namespace Busca_Lagura
{
	public class Program
	{

		public static char Menu()
		{
			Console.Clear();
			Console.WriteLine("A - Exibir grafo");
			Console.WriteLine("B - Incluir vértice");
			Console.WriteLine("C - Incluir aresta");
			Console.WriteLine("D - Remover vértice");
			Console.WriteLine("E - Remover aresta");
			Console.WriteLine("F - Reiniciar grafo");
			Console.WriteLine("H - Busca em Largura");
			Console.WriteLine("I - Sair");			
			Console.Write("Opção: ");

			return char.Parse(Console.ReadLine().ToLower());
		}


		static void Main(string[] args)
		{

			char opcao;

			do
			{
				opcao = Menu();

				switch (opcao)
				{
					// EXIBIR GRAFO
					case 'a':

						Console.ReadKey();
						break;

					// INCLUIR VERTICE NO GRAFO
					case 'b':

						Console.ReadKey();
						break;

					// INCLUIR ARESTA NO GRAFO
					case 'c':

						Console.ReadKey();
						break;

					// REMOVER ARESTA DO GRAFO
					case 'd':

						Console.ReadKey();
						break;

					// REMOVER VERTICE DO GRAFO
					case 'e':

						Console.ReadKey();
						break;

					// REINICIAR GRAFO
					case 'f':

						Console.ReadKey();
						break;

					// BUSCA EM LARGURA
					case 'H':

						Console.ReadKey();
						break;

					// DEFAULT
					default:

					Console.WriteLine("Opção inválida!\nPor favor digite uma opção válida. ");

						Console.ReadKey();
						break;
				}

			} while (opcao != 'i');
		}
	}
}
