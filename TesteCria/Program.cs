using System;
using Business.Logics;
using CrossCutting.Extensions;
using Infra.Context;

namespace TesteCria
{
    class Program
    {
        static void Main(string[] args)
        {
            var unitOfWork = new UnitOfWork();
            var WordLogics = new WordLogics(unitOfWork);

            while (true)
            {
                Console.Write("Digite a palavra a ser buscada: ");
                var palavra = Console.ReadLine();
                Console.WriteLine($"Procurando {palavra}");

                var result = WordLogics.GetWord(palavra);

                Console.WriteLine("------------------------------");
                Console.WriteLine($"Achada: {result.FoundWord} | Gatos Mortos: {result.DeadCats}");
                Console.WriteLine("------------------------------");
            }
        }
    }
}
