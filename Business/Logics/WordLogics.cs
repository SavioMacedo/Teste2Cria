using Business.Entities;
using Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Logics
{
    public class WordLogics
    {
        private IUnitOfWork UnitOfWork { get; set; }
        
        public WordLogics(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public Result GetWord(string word) 
        {
            var result = new Result();

            BinarySearch(word, 0, 10000, ref result);

            return result;
        }

        private Result BinarySearch(string word, int start, int end, ref Result result)
        {
            var value = "";
            var lastIndexException = 0;

            do
            {
                var mid = (start + end) / 2;

                try
                {
                    value = UnitOfWork.Word.GetAsync(mid).GetAwaiter().GetResult().Replace("\"","");

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
                            result.DeadCats++;
                            end = mid;
                        }
                        else
                        {
                            result.DeadCats++;
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
                    result.DeadCats++;
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
