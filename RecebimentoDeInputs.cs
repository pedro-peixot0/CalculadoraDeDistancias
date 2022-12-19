using System;
using System.Globalization;

namespace Questao1
{
    public partial class CalculadoraDeDistancias
    {
        static decimal ReceberInput(string message, string inputType)
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

        static decimal ConverterInput(List<char> input)
        {
            string inputString = new string(input.ToArray());
            inputString = inputString == "" ? "0" : inputString;
            //tryParse para dizer que o númro é muito grande
            decimal outputDecimal = decimal.Parse(inputString);
            
            return outputDecimal;
        }
    }
}