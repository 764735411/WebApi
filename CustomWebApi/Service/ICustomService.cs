using CustomWebApi.Model;
using CustomWebApi.Tool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomWebApi.Service
{
    public interface ICustomService
    {
        
        public Task<List<Custom>> SelectAllCustom();

        public Task<string> DeleteById(int id);

        public Task<Custom> SelectCustomById(int id);

        public Task<string> UpdateCustomById(Custom custom, int id);

        public Task<string> AddCustom(Custom custom);
        public Task<List<Custom>> SelectCustomByElement(CustomQuery customQuery);


    }
}
