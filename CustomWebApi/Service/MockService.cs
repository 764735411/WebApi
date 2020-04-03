using CustomWebApi.Model;
using CustomWebApi.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomWebApi.Service
{
    public class MockService : ICustomService
    {
        public Task<object> AddCustom(Custom custom)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteById(int id)
        {
            return Task.FromResult(1);
        }

        public Task<List<Custom>> SelectAllCustom()
        {
            return Task.FromResult( new List<Custom>());
        }

        public Task<List<Custom>> SelectCustomByElement(CustomQuery customQuery)
        {
            throw new NotImplementedException();
        }

        public Task<Custom> SelectCustomById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateCustomById<Custom>(Custom custom, int id)
        {
            return Task.FromResult(1);
        }

        public Task<string> UpdateCustomById(Custom custom, int id)
        {
            throw new NotImplementedException();
        }

        Task<string> ICustomService.AddCustom(Custom custom)
        {
            throw new NotImplementedException();
        }

        Task<string> ICustomService.DeleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
