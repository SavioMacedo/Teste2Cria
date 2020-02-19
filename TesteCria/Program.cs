using System;
using Business.Interfaces;
using CrossCutting.Extensions;
using CrossCutting.IoC;
using Infra.Context;
using Microsoft.Extensions.DependencyInjection;

namespace TesteCria
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddInjections()
                .BuildServiceProvider();

            var WorldLogics = serviceProvider.GetService<IWordLogics>();


            while (true)
            {
                Console.Write("Digite a palavra a ser buscada: ");
                var palavra = Console.ReadLine();
                Console.WriteLine($"Procurando {palavra}");

                var result = WorldLogics.GetWord(palavra);

                Console.WriteLine("------------------------------");
                Console.WriteLine($"Achada: {result.FoundWord} | Gatos Mortos: {result.DeadCats} | Indice: {result.Index}");
                Console.WriteLine("------------------------------");
            }
        }
    }
}
