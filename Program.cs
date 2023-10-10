using System.Windows.Input;
using UnixUtilities.Comandos;

internal class Program {
    private static void Main(string[] args) {

        void TerminalTitle(string word) {
            for (int i = 0; i < word.Length; i++) {
                Console.Write("*");
            }
            Console.WriteLine();
            Console.WriteLine(word);
            for (int i = 0; i < word.Length; i++) {
                Console.Write("*");
            }
            Console.WriteLine();
        }

        void Menu() {
            Console.WriteLine($@"Os comandos disponíves são:

0) sair           
1) ls
                ");
        }
        TerminalTitle("Bem Vindo ao meu Terminal Personalizado ! XD\n\n");

        Menu();

        bool rodando = true;
        while (rodando) {

            try {
                Console.WriteLine("Digite o numero do comando que gostaria de utilizar: ");

                string numeroOp = Console.ReadLine();
                switch (int.Parse(numeroOp)) {
                    case 1:
                        Ls.List();
                        break;
                    case 0:
                        rodando = false;
                        break;
                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }


        }





    }
}