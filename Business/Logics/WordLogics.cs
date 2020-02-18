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
                    value = UnitOfWork.Word.Get(mid);

                    if (value == word)
                    {
                        result.FoundWord = true;
                        return result;
                    }
                    else if (end <= start)
                    {
                        result.FoundWord = false;
                        return result;
                    }
                    else
                    {

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
                            end *= 2;
                        }
                    }
                }
                //catch (Exception erro)
                //{
                //    result.DeadCats++;
                //    end = mid;
                //}
                catch (IndexOutOfRangeException erro)
                {
                    result.DeadCats++;
                    lastIndexException = mid;
                    end = mid;
                }
            }
            while (value != word && end > start);

            result.FoundWord = false;
            return result;
        }
    }
}
