using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace App_Cadastro_Series
{
    class Program
    {
         static SerieRepositorio repositorio = new SerieRepositorio();
        static void  Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarSeries();
						break;
					case "2":
						InserirSerie();
						break;
					case "3":
						AtualizarSerie();
						break;
					case "4":
						ExcluirSerie();
						break;
					case "5":
						VisualizarSerie();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirSerie()
		{
			Console.Write("Digite o id da serie: ");
			int indiceSerie = int.Parse(Console.ReadLine()!);

			repositorio.Exclui(indiceSerie);
		}

        private static void VisualizarSerie()
		{
			Console.Write("Digite o id da serie: ");
			int indiceSerie = int.Parse(Console.ReadLine()!);

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
		}

        private static void AtualizarSerie()
		{
			Console.Write("Digite o id da serie: ");
			int indiceSerie = int.Parse(Console.ReadLine()!);

			
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o genero entre as opcoes acima: ");
			int entradaGenero = int.Parse(Console.ReadLine()!);

			Console.Write("Digite o Titulo da Serie: ");
			string entradaTitulo = Console.ReadLine()!;

			Console.Write("Digite o Ano de Inicio da Serie: ");
			int entradaAno = int.Parse(Console.ReadLine()!);

			Console.Write("Digite a Descrição da Serie: ");
			string entradaDescricao = Console.ReadLine()!;

			Serie atualizaSerie = new Serie(id: indiceSerie, genero:(Genero)entradaGenero, titulo:entradaTitulo, ano:entradaAno, descricao:entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
		}
        private static void ListarSeries()
		{
			Console.WriteLine("Listar series");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma serie cadastrada.");
				return;
			}

			foreach (var serie in lista)
			{
                var excluido = serie.retornaExcluido();
                
				Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
			}
		}

        private static void InserirSerie()
		{
			Console.WriteLine("Inserir nova série");

			
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine()!);

			Console.Write("Digite o Título da Serie: ");
			string entradaTitulo = Console.ReadLine()!;

			Console.Write("Digite o Ano de Início da Serie: ");
			int entradaAno = int.Parse(Console.ReadLine()!);

			Console.Write("Digite a Descrição da Serie: ");
			string entradaDescricao = Console.ReadLine()!;

			Serie novaSerie = new Serie(id: repositorio.ProximoId(), genero:(Genero)entradaGenero,  titulo: entradaTitulo, ano: entradaAno, descricao: entradaDescricao);

			repositorio.Insere(novaSerie);
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Iniciano app series!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar séries:");
			Console.WriteLine("2- Inserir nova série:");
			Console.WriteLine("3- Atualizar série:");
			Console.WriteLine("4- Excluir série:");
			Console.WriteLine("5- Visualizar série:");
			Console.WriteLine("C- Limpar Tela:");
			Console.WriteLine("X- Sair:");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine()!.ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
        }
    }    
}
