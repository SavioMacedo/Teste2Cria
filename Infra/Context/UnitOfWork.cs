using Business.Entities;
using Business.Interfaces;
using Infra.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Infra.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        public string[] FileStream { get; set; }
        private string path = "C:\\Users\\savio\\OneDrive\\Documentos\\palavras.txt";

        public UnitOfWork()
        {
            FileStream = File.ReadAllLines(path: path);
            Word = new Repository<Word>
            {
                UnitOfWork = this
            };
        }

        public IRepository<Word> Word { get; set; }
    }
}
