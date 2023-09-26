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
            Console.Write("Informe o valor presente: R$");
            rendimento.valor = Convert.ToDouble(Console.ReadLine());
            Console.Write("Informe o juros: ");
            rendimento.juros = Convert.ToDouble(Console.ReadLine());
            Console.Write("Informe o periodo (ano): ");
            rendimento.periodoAno = Convert.ToDouble(Console.ReadLine());
            Console.Write("Informe o periodo (mês): ");
            rendimento.periodoMes = Convert.ToDouble(Console.ReadLine());
            Console.Write("Informe o periodo (dia): ");
            rendimento.periodoDia = Convert.ToDouble(Console.ReadLine());
            Console.Write("Vai sacar? [S/N] ");
            rendimento.decisao = Console.ReadLine();
            if(rendimento.resgate){
                rendimento.valResgateMes = rendimento.periodoMes+1;
                while(rendimento.valResgateMes>rendimento.periodoMes){
                    Console.Write("Que periodo vai sacar: ");
                    rendimento.valResgateMes = Convert.ToInt64(Console.ReadLine());
                    if(rendimento.valResgateMes>rendimento.periodoMes){
                        Console.WriteLine("período maior que o tempo de rendimento!");
                    }
                }
                Console.Write("Quanto vai sacar: R$");
                rendimento.valResgate = Convert.ToDouble(Console.ReadLine());
            }
            rendimento.exibeDados();
            Console.ReadKey();
        }
    }
}
