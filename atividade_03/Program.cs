// See https://aka.ms/new-console-template for more information
using System;
using System.ComponentModel;

namespace exercicios{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Programa de Cálculo de juros compostos");
            Rendimento rendimento = new Rendimento();
            Console.WriteLine("Calculo de rendimento de juros compostos");
            Console.Write("Informe o valor presente: R$");
            rendimento.valor = Convert.ToDouble(Console.ReadLine());
            Console.Write("Informe o juros: ");
            rendimento.juros = Convert.ToDouble(Console.ReadLine());
            Console.Write("Informe o periodo: ");
            rendimento.periodo = Convert.ToDouble(Console.ReadLine());
            if(rendimento.periodo>=5){
                Console.Write("Vai sacar? [S/N] ");
                rendimento.decisao = Console.ReadLine();
                if(rendimento.resgate){
                    Console.Write("Que periodo vai sacar: ");
                    rendimento.valResgateMes = Convert.ToInt64(Console.ReadLine());
                    Console.Write("Quanto vai sacar: R$");
                    rendimento.valResgate = Convert.ToDouble(Console.ReadLine());
                }
            }
            rendimento.exibeDados();
            Console.ReadKey();
        }
    }
}