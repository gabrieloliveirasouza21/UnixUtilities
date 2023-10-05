/* 
Dividir a entrada do usuário em partes (split) com o pipe " | "
Cada uma dessas partes vão para uma posição do array de comandos
para eu saber qual é o próximo comando para ser executados e criar uma
cadeia de comandos irei pegar as duas primeiras letras do comando.

se não tiver nenhum comando será null
então preciso de dois métodos para cada comando
- um que chama apenas ele quando não houver mais comandos a serem 
executas em cadeia
- e outro para quando é chamado outro comando em cadeia, e esse segundo 
comando será parâmetro do método, quando ele for finalizado irá chamar
o outro método.

porém se for três comandos, vai ter que passar o terceiro comando como
parâmetro para o segundo, isso pode ser resolvido com um laço de 
repetição, onde ele vai repetindo contando as repetições, e o core do 
programa será executado por lá, a cada repetição ele pega a posição 
do comando no array, quando não tiver mais nenhuma posição posterior,
ele para - array.lenght


====================================

solucao 1 : criar um arquivo com esses comandos.
quando o usuario digitar algum input, irá verificar se o comando de input
está no arquivo
se for mais de um comando separado por pipe, deverá verificar um por um

solucao 2 : criar um array com os comandos e pegar o input do usuario e
comparar com os elementos do array (implementar algoritmo de busca)

em qualquer uma das duas tenho que separar pelo espaço (dar um split)
para pegar apenas o comando, geralmente o que vem apos o espaço não é 
comando, problema vai ser quando implementar uma flag

solucao 2 é melhor, talvez fazer um dicionario onde a chave são 
os comandos ,e o valor é o array de flags,
e quando houver input eu faço o split nele, verifico todos os elementos
do array se são comandos ou não, quais são e quais posições eles estão
o que for comando eu pego ele até a posição do próximo comando -1, junto
ele, terei que separar novamente em um array, para verificar a flag 
(se houver) e o argumento, dependendo do comando ele vai chamar a função
específica, verificandose há uma flag válida - no dicionario - e 
executando de acordo com o argumento.
 */



internal class Program {
    private static void Main(string[] args) {
        bool rodando = true;

        void Usuario() {
            Console.Write(Environment.UserName + "$> ");
        }

        while (rodando) {
            Usuario();
            string comando = Console.ReadLine();

            string[] cadeiaComandos = comando.Split('|');

            for (int i = 0; i < cadeiaComandos.Length; i++) {
                cadeiaComandos[i] = cadeiaComandos[i].Trim();
            }


            string proximoComando = null;

            //Console.WriteLine("Tamanho do array: " + cadeiaComandos.Length);

            if (cadeiaComandos.Length > 0 && comando != "exit") {
                
                string elemento1 = cadeiaComandos[0];
                char[] charDosElementos = elemento1.ToCharArray();
                string duasPrimeirasLetras = charDosElementos[0].ToString() + charDosElementos[1].ToString();



                if (cadeiaComandos.Length < 2) {
                    if (duasPrimeirasLetras.Equals("ls")) {
                        Console.WriteLine("Chamando apenas o ls");
                    } else if (duasPrimeirasLetras.Equals("ca")) {
                        Console.WriteLine("Chamando apenas o cat");
                    } else if (duasPrimeirasLetras.Equals("gr")) {
                        Console.WriteLine("Chamando apenas o grep");
                    } else if (duasPrimeirasLetras.Equals("le")) {
                        Console.WriteLine("Chamando apenas o less");
                    } else if (duasPrimeirasLetras.Equals("so")) {
                        Console.WriteLine("Chamando apenas o sort");
                    } else if (duasPrimeirasLetras.Equals("ta")) {
                        Console.WriteLine("Chamando apenas o tail");
                    } else if (duasPrimeirasLetras.Equals("wc")) {
                        Console.WriteLine("Chamando apenas o wc");
                    } else {
                        Console.WriteLine("Comando não reconhecido !");
                    }
                }


                if (cadeiaComandos.Length >= 2) {
                    if (duasPrimeirasLetras.Equals("ls") &&
                        cadeiaComandos[1] != null) {
                        Console.WriteLine("camando o ls + " + cadeiaComandos[1].ToString());
                    }
                    else if (duasPrimeirasLetras.Equals("ca") &&
                        cadeiaComandos[1] != null) {
                        Console.WriteLine("camando o ca + " + cadeiaComandos[1].ToString());
                    } 
                    else if (duasPrimeirasLetras.Equals("gr") &&
                        cadeiaComandos[1] != null) {
                        Console.WriteLine("camando o grep + " + cadeiaComandos[1].ToString());
                    }
                    else if (duasPrimeirasLetras.Equals("le") &&
                        cadeiaComandos[1] != null) {
                        Console.WriteLine("camando o less + " + cadeiaComandos[1].ToString());
                    }
                    else if (duasPrimeirasLetras.Equals("so") &&
                        cadeiaComandos[1] != null) {
                        Console.WriteLine("camando o sort + " + cadeiaComandos[1].ToString());
                    }
                    else if (duasPrimeirasLetras.Equals("ta") &&
                        cadeiaComandos[1] != null) {
                        Console.WriteLine("camando o tail + " + cadeiaComandos[1].ToString());
                    }
                    else if (duasPrimeirasLetras.Equals("wc") &&
                        cadeiaComandos[1] != null) {
                        Console.WriteLine("camando o wc + " + cadeiaComandos[1].ToString());
                    }
                }
            }

            if (comando.Equals("exit")) {
                rodando = false;
            }

        }

        Usuario();
    }
}