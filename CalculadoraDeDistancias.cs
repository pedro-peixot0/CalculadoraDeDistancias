using System;
using System.Globalization;

namespace Questao1
{
    public class Testes
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
Olá, este programa recebe as distancias entre cidades e, com elas,
consegue calcular distância de um caminho definido pelo usuário.
");
            var tabela = new CalculadoraDeDistancias();
            tabela.CalcularDistanciaCaminho();
        }
    }
    public partial class CalculadoraDeDistancias
    {
        private decimal[][] arrayDistancias;

        public CalculadoraDeDistancias()
        {
            int tamanhoArray = (int) ReceberInput(
                message: "Por favor, comece entrando a quantidade de cidades:",
                inputType: "int"
            );

            arrayDistancias = new decimal[tamanhoArray][];

            for (int i=0; i<tamanhoArray; i++)
            {
                arrayDistancias[i] = new decimal[tamanhoArray];
                for (int j=0; j< tamanhoArray; j++)
                {
                    if (i == j)
                        arrayDistancias[i][j] = 0M;
                    else if (j > i)
                        arrayDistancias[i][j] = ReceberInput(
                            message: $"\nPor favor, entre a distancia entre a cidade {i+1} e a cidade {j+1}:",
                            inputType: "decimal"
                        );
                    else
                        arrayDistancias[i][j] = arrayDistancias[j][i];
                }
            }
        }
        public void CalcularDistanciaCaminho()
        {
            List<int> caminho = new List<int>{};
            string stringCaminho = "Início -> ";
            int proximaCidade;
            
            do{
                proximaCidade = (int) ReceberInput(
                message: $"\n Por favor, entre a próxima cidade a ser visitada ou '0' para sair: \n {stringCaminho}",
                inputType: "int"
                );
                //while loop pegando erros

                if (proximaCidade == 0)
                    break;
                else if (proximaCidade > arrayDistancias.GetLength(0))
                {
                    Console.WriteLine($"\n\n {proximaCidade} não é o número de uma cidade válida!");
                    continue;
                }

                caminho.Add(proximaCidade - 1);
                stringCaminho += $" {proximaCidade} -> ";

            }while(proximaCidade != 0);

            Console.Clear();
            Console.WriteLine($"O caminho escolhido foi: \n {stringCaminho.Substring(0,stringCaminho.Length-3)}");

            decimal distancia = 0M;
            
            for (int i=1; i<caminho.Count; i++)
            {   
                distancia += this.arrayDistancias
                [(int) caminho[i]]
                [(int) caminho[i-1]]
                ;
            }

            Console.WriteLine($"\n A distancia total do caminho definido é de {distancia}");
        }
    }
}