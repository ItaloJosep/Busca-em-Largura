using System;

namespace Busca_Lagura
{
	public class Program
	{

		public static char Menu()
		{
			Console.Clear();
			Console.WriteLine("A - Exibir grafo");
			Console.WriteLine("B - Incluir cidade (vértice)");
			Console.WriteLine("C - Conectar cidades");
			Console.WriteLine("D - Remover cidade");
			Console.WriteLine("E - Remover conexão");
			Console.WriteLine("F - Reiniciar grafo");
			Console.WriteLine("H - Busca em Largura");
			Console.WriteLine("I - Sair");			
			Console.Write("Opção: ");

			return char.Parse(Console.ReadLine().ToLower());
		}


		static void Main(string[] args)
		{

			Grafo grafo = new Grafo();
			char opcao;
			string cidade, cidadeIn, cidadeFim;

			do
			{
				opcao = Menu();

				switch (opcao)
				{
					// EXIBIR GRAFO
					case 'a':
						Console.Clear();
						grafo.ExibirGrafo();

						Console.ReadKey();
						break;

					// INCLUIR CIDADE NO GRAFO
					case 'b':
						Console.Clear();
						Console.Write("Entre com o da cidade...: ");
						cidade = Console.ReadLine();

						if (grafo.VerificarCidade(cidade))
							Console.WriteLine("{0}, já se encontra no grafo! \nPor favor digite uma outr cidade.");
						
						else						
							grafo.IncluirCidade(cidade);						

						Console.ReadKey();
						break;
							
					// CONECTAR CIDADES DO GRAFO
					case 'c':
						Console.Clear();
						Console.Write("Digite o nome da cidade inicial...: ");
						cidadeIn = Console.ReadLine();
						Console.Write("Digite o nome da cidade final...: ");
						cidadeFim = Console.ReadLine();

						if (cidadeIn.Trim().ToLower().Equals(cidadeFim.Trim().ToLower()))
							Console.WriteLine("As cidades devem ser diferentes.");

						else
						{
							if (!grafo.VerificarCidade(cidadeIn) || !grafo.VerificarCidade(cidadeFim))
								Console.WriteLine("A cidade {0} e/ou a cidade {1} não existem no grafo.", cidadeIn, cidadeFim);

							else
							{
								if (grafo.VerificarConexao(cidadeIn, cidadeFim))
									Console.WriteLine("A aresta entre o vértice {0} e o vértice {1} já existe no grafo.", cidadeIn, cidadeFim);

								else
									grafo.IncluirConexao(cidadeIn, cidadeFim);
							}
						}

						Console.ReadKey();
						break;

					// REMOVER CIDADE DO GRAFO
					case 'd':
						Console.Clear();
						Console.Write("Digite o nome da cidade...: ");
						cidade = Console.ReadLine();

						if (!grafo.VerificarCidade(cidade))
							Console.WriteLine("A cidade {0} não existe no grafo.", cidade);
						else
							grafo.RemoverCidade(cidade);

						Console.ReadKey();
						break;

					// REMOVER CONEXAO DAS CIDADES DO GRAFO
					case 'e':
						Console.Clear();
						Console.Write("Digite o nome da cidade inicial...: ");
						cidadeIn = Console.ReadLine();
						Console.Write("Digite o nome da cidade final...: ");
						cidadeFim = Console.ReadLine();

						if (!grafo.VerificarCidade(cidadeIn) || !grafo.VerificarCidade(cidadeFim))
							Console.WriteLine("A cidade {0} e/ou a cidade {1} não existem no grafo.", cidadeIn, cidadeFim);
						else
						{
							if (!grafo.VerificarConexao(cidadeIn, cidadeFim))
								Console.WriteLine("A conexão entre a cidade {0} e a cidade {1} não existe no grafo.", cidadeIn, cidadeFim);
							else
								grafo.RemoverConexao(cidadeIn, cidadeFim);
						}

						Console.ReadKey();
						break;

					// REINICIAR GRAFO
					case 'f':
						Console.Clear();

						grafo.ReiniciarGrafo();

						Console.ReadKey();
						break;

					// BUSCA EM LARGURA
					case 'H':
						Console.Clear();

						Console.ReadKey();
						break;

					// DEFAULT
					default:
						Console.Clear();

						Console.WriteLine("Opção inválida!\nPor favor digite uma opção válida. ");

						Console.ReadKey();
						break;
				}

			} while (opcao != 'i');
		}
	}
}
