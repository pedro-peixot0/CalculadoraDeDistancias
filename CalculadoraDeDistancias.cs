using System;
using System.Globalization;

namespace Questao1
{
    public class Testes
    {
        static void Main(string[] args)
        {    
            var tabela = new CalculadoraDeDistancias(
                tipoInputTabelaDistancias: "csvhelper",
                tipoInputCaminho:"csvhelper"
            );

            tabela.CalcularDistanciaCaminho();
        }
    }
    public partial class CalculadoraDeDistancias
    {
        string mensagemInicial = @"
Olá, este programa recebe as distancias entre cidades e, com elas,
consegue calcular distância de um caminho definido pelo usuário.
";   
        private decimal[][] arrayDistancias;
        private List<decimal> listaCaminho;
  
        //Os argumentos podem ser: "csv","csvhelper","default"
        public CalculadoraDeDistancias(string tipoInputTabelaDistancias = "default", string tipoInputCaminho = "default")
        {
            Console.WriteLine(this.mensagemInicial);
            ReceberTabelaDistancias(tipoInput: tipoInputTabelaDistancias);
            ReceberCaminho(tipoInput: tipoInputCaminho);
        }
        public CalculadoraDeDistancias(decimal[][] arrayDistancias, List<decimal> caminho)
        {
            Console.WriteLine(this.mensagemInicial);
            this.arrayDistancias = arrayDistancias;
            this.listaCaminho = caminho;
        }
        public decimal CalcularDistanciaCaminho()
        {
            decimal distancia = 0M;
            
            for (int i=1; i<this.listaCaminho.Count; i++)
            {   
                distancia += this.arrayDistancias
                [(int) (this.listaCaminho[i]-1)]
                [(int) (this.listaCaminho[i-1]-1)];
            }
            
            Console.WriteLine($"O caminho escolhido foi: \n {string.Join(" -> ",this.listaCaminho)}");
            Console.WriteLine($"\n A distancia total do caminho definido é de {distancia}");

            return distancia;
        }
    }
}