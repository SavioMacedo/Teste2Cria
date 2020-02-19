using Business.Entities;
using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Logics
{
    public class WordLogics : IWordLogics
    {
        private IUnitOfWork UnitOfWork { get; set; }

        public WordLogics(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public Result GetWord(string word)
        {
            var result = new Result();

            BinarySearch(word, 0, 1, ref result);

            return result;
        }

        private Result BinarySearch(string word, int start, int end, ref Result result)
        {
            var value = "";
            var repetitiveIndex = new List<int>();
            var lastIndexException = 0;

            do
            {
                var mid = (start + end) / 2;

                try
                {

                    while (repetitiveIndex.Contains(mid))
                    {
                        mid++;
                    };

                    value = UnitOfWork.Word.GetAsync(mid).GetAwaiter().GetResult().Replace("\"", "");
                    result.DeadCats++;

                    if (value == word)
                    {
                        result.FoundWord = true;
                        result.Index = mid;
                        return result;
                    }
                    else if (end <= start)
                    {
                        result.FoundWord = false;
                        result.Index = 00000000000;
                        return result;
                    }
                    else
                    {
                        //var firstValue = value.Substring(0, 1);
                        //var firstWord = word.Substring(0, 1);

                        //var compare = firstValue.CompareTo(firstWord);
                        var compare = value.CompareTo(word);

                        if (compare == 1)
                        {
                            repetitiveIndex.Add(mid);
                            end = (mid == 0) ? 1 : mid;
                        }
                        else
                        {
                            start = mid;

                            if (lastIndexException != 0 && (end * 2) > lastIndexException)
                            {
                                var random = new Random();
                                end = random.Next(mid, lastIndexException);
                            }
                            else
                                end *= 2;
                        }
                    }
                }
                catch (Exception erro)
                {
                    lastIndexException = end;
                    end = mid;
                }
            }
            while (value != word && end > start);

            result.FoundWord = false;
            result.Index = 000000000000;
            return result;
        }
    }
}
