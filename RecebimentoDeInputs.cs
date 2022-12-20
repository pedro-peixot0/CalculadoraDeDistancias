using System.Globalization;

namespace Questao1
{
    public partial class CalculadoraDeDistancias
    {
        private decimal[][] ReceberTabelaDistanciasManualmente()
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

            return arrayDistancias;
        }
        private List<decimal> ReceberTabelaCaminhoManualmente ()
        {
            List<decimal> caminho = new List<decimal>{};
            string stringCaminho = "Início -> ";
            decimal proximaCidade;
            
            do{
                proximaCidade = ReceberInput(
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

                caminho.Add(proximaCidade);
                stringCaminho += $" {proximaCidade} -> ";

            }while(proximaCidade != 0);

            return caminho;
        }
        private decimal ReceberInput(string message, string inputType)
        {
            //Controle do do separador decimal
            char decimalChar = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            bool jaTemSeparador = false;

            Console.Write(message + " 0");

            List<char> listaInputs = new List<char> {};
            ConsoleKey keyInfo = ConsoleKey.A;
            decimal inputDecimal = 0M;
            

            while (keyInfo != ConsoleKey.Enter) {
                
                //Recebendo inputs do usuário
                ConsoleKeyInfo key = Console.ReadKey();
                keyInfo = key.Key;
                
                //inserindo inputs
                if (Char.IsDigit(key.KeyChar) && listaInputs.Count<29)
                {             
                    listaInputs.Insert(listaInputs.Count, key.KeyChar);
                }
                else if (key.KeyChar == decimalChar && inputType == "decimal" && !jaTemSeparador)
                {
                    if (listaInputs.Count > 0)
                    {
                        listaInputs.Insert(listaInputs.Count, key.KeyChar);
                        jaTemSeparador = true;
                    }
                    else
                    {
                        listaInputs.Insert(listaInputs.Count, '0');
                        listaInputs.Insert(listaInputs.Count, key.KeyChar);
                        jaTemSeparador = true; 
                    }
                }
                //apagando inputs
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (listaInputs.Count>0)
                    {
                        if(listaInputs[listaInputs.Count-1] == decimalChar)
                            jaTemSeparador = false;
                        listaInputs.RemoveAt(listaInputs.Count -1);
                    }
                }
                
                Console.Clear();
                Console.Write($"{message} {new string(listaInputs.ToArray())}");
            } 

            inputDecimal = ConverterInput(listaInputs);
            return inputDecimal; 
        }
        private decimal ConverterInput(List<char> input)
        {
            string inputString = new string(input.ToArray());
            inputString = inputString == "" ? "0" : inputString;
            //tryParse para dizer que o númro é muito grande
            decimal outputDecimal = decimal.Parse(inputString);
            
            return outputDecimal;
        }
    }
}
