using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TaskChainingAsync.Core;

namespace TaskChainingAsync.Test
{
    public class ArrayMannagerTest
    {
        private readonly IArrayManager _arrayManger;

        public ArrayMannagerTest()
        {
            _arrayManger = new ArrayManager();
        }

        [TestCase(1, 100)]
        [TestCase(-100, 100)]
        public async Task CreateRandomArraySuccess(int min, int max)
        {
            var res = await _arrayManger.CreateRandomArrayAsync(min, max);
            Assert.IsNotNull(res);
            Assert.AreEqual(10, res.Length);
        }

        [TestCase(1000, 100)]
        [TestCase(-100, -1000)]
        public async Task CreateRandomArrayFailure(int min, int max)
        {
            Assert.ThrowsAsync<ArgumentException>(async() => await _arrayManger.CreateRandomArrayAsync(min, max));
            await Task.CompletedTask;
        }

        [TestCase(new[] { 5, 15, 25, 35, 45 }, 10, ExpectedResult = new[] { 50, 150, 250, 350, 450 })]
        [TestCase(new[] { -10, -9, -5, 0, 0, 5, 1, 2 }, 10, ExpectedResult = new[] { -100, -90, -50, 0, 0, 50, 10, 20 })]
        public async Task<int[]> MultiplyArrayByNumberSuccess(int[] array, int mult)
        {
            return await _arrayManger.MultiplyArrayByNumberAsync(array, mult);
        }

        [Test]
        public async Task MultiplyArrayByNumberFailure()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _arrayManger.MultiplyArrayByNumberAsync(null, 10));
            await Task.CompletedTask;
        }

        [Test]
        public async Task MultiplyArrayByNumberFailure2()
        {
            Assert.ThrowsAsync<ArgumentException>(async() => await _arrayManger.MultiplyArrayByNumberAsync(Array.Empty<int>(), 10));
            await Task.CompletedTask;
        }

        [TestCase(new[] { 5, 15, 25, 35, 45 }, ExpectedResult = new[] { 5, 15, 25, 35, 45 })]
        [TestCase(new[] { -10, -9, -5, 0, 0, 5, 1, 2 }, ExpectedResult = new[] { -10, -9, -5, 0, 0, 1, 2, 5 })]
        public async Task<int[]> SortArrayByAscendingSuccess(int[] array)
        {
            return await _arrayManger.SortArrayByAscendingAsync(array);
        }

        [Test]
        public async Task SortArrayByAscendingFailure()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _arrayManger.SortArrayByAscendingAsync(null));
            await Task.CompletedTask;
        }

        [Test]
        public async Task SortArrayByAscendingFailure2()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await _arrayManger.SortArrayByAscendingAsync(Array.Empty<int>()));
            await Task.CompletedTask;
        }

        [TestCase(new[] { 10, 10, 10, 10, 10 }, ExpectedResult = 10)]
        [TestCase(new[] { 5, 15, 25, 35, 45 }, ExpectedResult = 25)]
        public async Task<int> AverageValueSuccess(int[] array)
        {
            return await _arrayManger.AverageValueAsync(array);
        }

        [Test]
        public async Task AverageValueFailure()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _arrayManger.AverageValueAsync(null));
            await Task.CompletedTask;
        }

        [Test]
        public async Task AverageValueFailure2()
        {
            Assert.ThrowsAsync<ArgumentException>(async () => await _arrayManger.AverageValueAsync(Array.Empty<int>()));
            await Task.CompletedTask;
        }
    }
}