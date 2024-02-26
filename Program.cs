using UsuarioProgram.Models;
using UsuarioProgram.Repositorios;
using UsuarioProgram.Services;
using System;

namespace UsuarioProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var usuarioRepositorio = new UsuarioRepositorio();
            var usuarioService = new UsuarioService(usuarioRepositorio);

            while (true)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Consultar Usuários");
                Console.WriteLine("2. Incluir Usuário");
                Console.WriteLine("3. Excluir Usuário");
                Console.WriteLine("4. Sair");

                int opcao;
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida. Por favor, digite um número válido.");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        ConsultarUsuarios(usuarioService);
                        break;
                    case 2:
                        IncluirUsuario(usuarioService);
                        break;
                    case 3:
                        ExcluirUsuario(usuarioService);
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, escolha uma das opções disponíveis.");
                        break;
                }
            }
        }

        static void ConsultarUsuarios(UsuarioService usuarioService)
        {
            var usuarios = usuarioService.ConsultarUsuarios();
            Console.WriteLine("\nLista de Usuários:");
            if (usuarios.Count > 0)
            {
                foreach (var usuario in usuarios)
                {
                    Console.WriteLine($"Nome: {usuario.Nome}, CPF: {usuario.CPF}, Sexo: {usuario.Sexo}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum usuário cadastrado.");
            }
            Console.WriteLine();
        }

        static void IncluirUsuario(UsuarioService usuarioService)
        {
            Console.WriteLine("\nIncluir Usuário:");
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();
            Console.Write("Sexo: ");
            string sexo = Console.ReadLine();

            usuarioService.IncluirUsuario(new Usuario { Nome = nome, CPF = cpf, Sexo = sexo });

            Console.WriteLine("Usuário incluído com sucesso.\n");
        }

        static void ExcluirUsuario(UsuarioService usuarioService)
        {
            Console.WriteLine("\nExcluir Usuário:");
            Console.Write("Informe o CPF do usuário a ser excluído: ");
            string cpf = Console.ReadLine();

            usuarioService.ExcluirUsuario(cpf);
            Console.WriteLine("Usuário excluído com sucesso.\n");
        }
    }
}
