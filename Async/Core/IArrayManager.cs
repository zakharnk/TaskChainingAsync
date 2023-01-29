using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskChainingAsync.Core
{
    public interface IArrayManager
    {
        public Task<int[]> CreateRandomArrayAsync(int min, int max);
        public Task<int[]> MultiplyArrayByNumberAsync(int[] array, int number);
        public Task<int[]> SortArrayByAscendingAsync(int[] array);
        public Task<int> AverageValueAsync(int[] array);
    }
}
