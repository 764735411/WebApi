using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomWebApi.Model;
using CustomWebApi.Service;
using CustomWebApi.Tool;
using CustomWebApi.Validation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomController : ControllerBase
    {
        private ICustomService _customService;

        public CustomController(ICustomService customService)
        {
            this._customService = customService;
        }

        /// <summary>
        /// 查询所有顾客信息
        /// 版本v1
        /// </summary>
        /// <returns></returns>
        // GET: api/Custom
        [HttpGet("select/v1")]
        public async Task<IActionResult> GetAllCustomDataAsync()
        {
            List<Custom> customList = await _customService.SelectAllCustom();
            return new JsonResult(customList);
        }

        /// <summary>
        /// 根据id查询顾客信息
        /// 版本v1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Custom/5
        [HttpGet("select/v1/id={id}", Name = "Get")]
        public async Task<IActionResult> GetAsync(int id)
        {
            Custom custom = await _customService.SelectCustomById(id);
            return new JsonResult(custom);
        }

        /// <summary>
        /// 增加顾客信息
        /// 版本v1
        /// </summary>
        /// <param name="custom"></param>
        // POST: api/Custom
        [HttpPost("add/v1")]
        public async Task<IActionResult> PostCustomAsync([FromBody] Custom custom)
        {
            string addResultMessage  =  await _customService.AddCustom(custom);
            return Content(addResultMessage);
        }

        /// <summary>
        /// 修改顾客信息
        /// 版本v1
        /// </summary>
        /// <param name="id"></param>
        /// <param name="custom"></param>
        // PUT: api/Custom/5
        [HttpPut("update/v1/id={id}")]
        public async Task<IActionResult> PutCustomAsync(int id, [FromBody] Custom custom)
        {
            string putMessage = await _customService.UpdateCustomById(custom, id);
            return Content(putMessage);
        }

        /// <summary>
        /// 删除顾客信息
        /// 版本v1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("delete/v1/id={id}")]
        public async Task<IActionResult> DeleteCustomAsync(int id)
        {
            string deleteMessage = await _customService.DeleteById(id);
            return Content(deleteMessage);
        }
        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="customQuery"></param>
        /// <returns></returns>
        [HttpGet("select/v1/query")]
        public async Task<IActionResult> SelectByQuery([FromBody] CustomQuery customQuery)
        {                          
            List<Custom> customList  = await _customService.SelectCustomByElement(customQuery);
            return new JsonResult(customList);
        }
    }
}
