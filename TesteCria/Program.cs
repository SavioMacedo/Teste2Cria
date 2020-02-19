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

            var wordLogics = serviceProvider.GetService<IWordLogics>();


            while (true)
            {
                Console.Write("Digite a palavra a ser buscada: ");
                var word = Console.ReadLine();
                Console.WriteLine($"Procurando {word}");

                var result = wordLogics.GetWord(word);

                Console.WriteLine("------------------------------");
                Console.WriteLine($"Achada: {result.FoundWord} | Gatos Mortos: {result.DeadCats} | Indice: {result.Index}");
                Console.WriteLine("------------------------------");
            }
        }
    }
}
