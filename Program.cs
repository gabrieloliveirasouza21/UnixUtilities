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



using System.Windows.Input;

internal class Program {
    private static void Main(string[] args) {

        #region Criando o dicionario e adicionando os comandos
        Dictionary<string, List<object>> comandos = new Dictionary<string, List<object>>();

        List<object> flagsls = new List<object>();
        flagsls.Add("-txt");
        flagsls.Add("-pdf");
        flagsls.Add("--help");
        comandos.Add("ls", flagsls);

        List<object> flagsgrep = new List<object>();
        //...
        comandos.Add("grep", flagsgrep);

        List<object> flagsless = new List<object>();
        //...
        comandos.Add("less", flagsless);

        List<object> flagssort = new List<object>();
        //...
        comandos.Add("sort", flagssort);

        List<object> flagscat = new List<object>();
        //...
        comandos.Add("cat", flagscat);

        List<object> flagstail = new List<object>();
        //...
        comandos.Add("tail", flagstail);

        List<object> flagswc = new List<object>();
        //...
        comandos.Add("wc", flagswc);


        #endregion


        bool rodando = true;

        #region Nome do Usuario
        void Usuario() {
            Console.Write(Environment.UserName + "$> ");
        }
        #endregion

        while (rodando) {
            Usuario();
            string comando = Console.ReadLine();

            string[] cadeiaComandos = comando.Split(' ');
            List<int> posDosComandos = new List<int>();

            for (int i = 0; i < cadeiaComandos.Length; i++) {
                cadeiaComandos[i] = cadeiaComandos[i].Trim();
            }

            if (comando.Equals("exit")) {
                rodando = false;
            } else {
                int contPos = 0;

                string corpoComando;

                #region verificar se o comando é valido
                foreach (var comand in cadeiaComandos) {
                    foreach (var coman in comandos) {
                        if (comand.ToLower() == coman.Key) {
                            Console.WriteLine("O " + comand + " e valido");
                            posDosComandos.Add(contPos);
                            break;

                        } else {
                            Console.WriteLine("O " + comand + " nao e valido");

                        }

                    }
                    contPos++;
                }
                #endregion

                //loop infinito aqui em algum lugar... resolver
                string comandoASerExecutado = "";
                for (int i = 0; i < cadeiaComandos.Length; i++) {
                    for (int num = 0; num < posDosComandos.Count; num++) {
                        if (i % 4 == 0 && i == 0) {

                            for (int j = i; j < cadeiaComandos.Length;i++) {
                                if (j > 4) {
                                    break;
                                }

                                comandoASerExecutado += cadeiaComandos[j].ToString();

                            }

                        }
                        else if (i % 4 == 0 && i != 0) {
                            for (int j = i; j < cadeiaComandos.Length; j++) {
                                if (j == posDosComandos[i+4]) {
                                    break;
                                }

                                comandoASerExecutado += cadeiaComandos[j].ToString();

                            }
                            
                        }

                
            }
        }
                Console.WriteLine(comandoASerExecutado);


                /* 
                 agora que eu já tenho a posição dos comandos principais, 
                eu tenho que, a partir do segundo, pegar ele menos 4 
                (pois como é sempre comando -flag argumento, e tem o " | "), eles 
                vão ser divisiveis por 4.
                terei que pegar o proximo comando -4, -3, -2 para criar uma string desse
                comando específico.

                essa string vai ser splitada, separando o comando da flag, do argumento
                irá fazer uma verificação no dicionario criado anteriormente percorrendo a 
                lista de flags para verificar se a flag digitada é valida, 
                se sim, irá chamar o método referente ao comando juntamente com a flag,
                se não houver nenhuma flag, ou ela for incorreta, 
                será chamado o método padrao.

                quando for comandos encadeados eu vou pegando a posição do proximo comando
                e sobrescrevendo a string que vai juntar o comando para ser separado pela 
                split, para fazer a verificação da flag e chamar o método específico.
                 */

            }



            foreach (var n in posDosComandos) {
                Console.Write(n + " ");
            }




            //string proximoComando = null;

            //Console.WriteLine("Tamanho do array: " + cadeiaComandos.Length);



        }

        Usuario();
    }
}