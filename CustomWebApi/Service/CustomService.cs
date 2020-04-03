using CustomWebApi.Model;
using CustomWebApi.Repository;
using CustomWebApi.Tool;
using CustomWebApi.Validation;
using FluentValidation;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomWebApi.Service
{
    public class CustomService:ICustomService
    {
        private readonly ICustomRepository _repository ;
        //private readonly PageTool _pageTool;

        public CustomService(ICustomRepository customRepository)
        {
            this._repository = customRepository;
            
        }
        /// <summary>
        /// 增加
        /// </summary>
        /// <returns></returns>
        public Task<string> AddCustom(Custom custom)
        {
            var task = Task.Run(() =>
            {
                string addMessage = "添加失败";
                CustomValidation _customValidation = new CustomValidation();
                var validationResult = _customValidation.Validate(custom);
                if (validationResult.IsValid)
                {
                    try
                    {
                        object o = _repository.AddData<Custom>(custom);
                        if (o != null)
                        {
                            addMessage = "添加成功";
                        }
                    }
                    catch (Exception e)
                    {
                        return addMessage = "添加失败";
                    }

                }
                else
                {
                    addMessage = validationResult.ToString();
                }
                return addMessage;
            });
            return task;
            
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<string> DeleteById(int id)
        {
            var task = Task.Run(() => {
                string deleteMessage = "删除失败，用户不存在或网络连接出现问题";
                if (_repository.SelectById<Custom>(id) != null)
                {
                    int result = _repository.DeleteById<Custom>(id);
                    if (result == 1)
                    {
                        deleteMessage = "删除成功";
                    }
                }
                return deleteMessage;
            });
            return task;
        }

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        public Task<List<Custom>> SelectAllCustom()
        {
            var task= Task.Run(()=>{
                List<Custom> customsList = _repository.SelectAllData<Custom>();
                return customsList;
            });
            return task;  
        }
        /// <summary>
        /// 模糊查询
        /// </summary>
        /// <param name="custom"></param>
        /// <returns></returns>
        public Task<List<Custom>> SelectCustomByElement(CustomQuery customQuery)
        {
            var task = Task.Run(() =>
            {
                Sql selectSql = new Sql();
                selectSql.Append("select * from Custom where 1=1");
                if (!string.IsNullOrEmpty(customQuery.CustomQueryName))
                {
                    selectSql.Append("and custom_name like @0", "%" + customQuery.CustomQueryName + "%");
                }
                if (!string.IsNullOrEmpty(customQuery.CustomQueryAge))
                {
                    selectSql.Append("and custom_age like @0", "%" + customQuery.CustomQueryAge + "%");
                }
                if (!string.IsNullOrEmpty(customQuery.CustomQuerySex))
                {
                    selectSql.Append("and custom_sex like @0", "%" + customQuery.CustomQuerySex + "%");
                }
                if (!string.IsNullOrEmpty(customQuery.CustomQueryIdCrad))
                {
                    selectSql.Append("and custom_idcrad like @0", "%" + customQuery.CustomQueryIdCrad + "%");
                }
                if (!string.IsNullOrEmpty(customQuery.CustomQueryPhone))
                {
                    selectSql.Append("and custom_idcrad like @0", "%" + customQuery.CustomQueryPhone + "%");
                }
                List<Custom> customs = _repository.SelectByQueryClass<Custom>(customQuery.PageNumber, customQuery.PageSize,selectSql);
                return customs;
            });
            return task;
        }

        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Custom> SelectCustomById(int id)
        {
            var task = Task.Run(() => {
                Custom custom = _repository.SelectById<Custom>(id);
                return custom;
            });
            return task;
        }
        /// <summary>
        /// 根据主键id更新
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<string> UpdateCustomById(Custom custom ,int id)
        {
            var task = Task.Run(() => {
                string putMessage = "修改顾客信息失败，用户不存在或网络连接出现问题";
                CustomValidation _customValidation = new CustomValidation();
                var validationResult = _customValidation.Validate(custom);
                if (validationResult.IsValid)
                {
                    int result = _repository.UpdateData(custom, id);
                    if (result == 1)
                    {
                        putMessage = "修改顾客信息成功";
                    }
                }
                else
                {
                    putMessage = validationResult.ToString();
                }
                return putMessage;
            });
            return task;
        }

    }
}