using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomWebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using CustomWebApi.Service;
using Microsoft.AspNetCore.Mvc;
using CustomWebApi.Model;
using CustomWebApi.Validation;
using CustomWebApi.Repository;
using CustomWebApi.Tool;

namespace CustomWebApi.Controllers.Tests
{
    [TestClass]

    public class CustomControllerTests
    {

        //CustomController controller;
        CustomService customService;
        public CustomControllerTests()
        {
            //controller = new CustomController(new CustomService(new CustomRepository()));
            customService = new CustomService(new CustomRepository());

        }
        /// <summary>
        /// 根据id查询测试
        /// </summary>
        /// <param name="id"></param>
        [TestMethod]
        [DataRow(1)]
        public void SelectByid_Test_Notnull(int id)
        {
            Custom custom = new Custom();
            custom.CustomName = "Tom";
            var result = customService.SelectCustomById(id);
            Assert.AreEqual(custom.CustomName, result.Result.CustomName);
        }

        [TestMethod]
        [DataRow(29)]
        [DataRow(20)]
        [DataRow(21)]
        public void SelectByid_Test_IsNull(int id)
        {
            var result = customService.SelectCustomById(id);
            Assert.IsNull(result.Result);
        }

        /// <summary>
        /// 增加数据测试
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="sex"></param>
        /// <param name="idcard"></param>
        /// <param name="phone"></param>
        [TestMethod]
        [DataRow("hup", "22", "男", "511303199209021123", "19012901232")]
        public void AddCustom_Test_DataNotNull(string name, string age, string sex, string idcard, string phone)
        {
            Custom custom = new Custom();
            custom.CustomName = name;
            custom.CustomAge = age;
            custom.CustomSex = sex;
            custom.CustomIdCrad = idcard;
            custom.CustomPhone = phone;
            string result = customService.AddCustom(custom).Result;
            Assert.AreEqual("添加成功", result);
        }

        [TestMethod]
        [DataRow(null, "22", "男", "511303199209021123", "19012901232")]
        public void AddCustom_Test_DataisNull(string name, string age, string sex, string idcard, string phone)
        {
            Custom custom = new Custom();
            custom.CustomName = name;
            custom.CustomAge = age;
            custom.CustomSex = sex;
            custom.CustomIdCrad = idcard;
            custom.CustomPhone = phone;
            string result = customService.AddCustom(custom).Result;
            Assert.AreEqual("姓名不能为空", result);
        }

        /// <summary>
        /// 模糊查询测试
        /// </summary>
        /// <param name="name"></param>
        [TestMethod]
        [DataRow("T")]
        public void SelectCustomByElement_Test(string name)
        {
            CustomQuery customQuery = new CustomQuery();
            customQuery.CustomQueryName = name;
            List<Custom> customs =  customService.SelectCustomByElement(customQuery).Result;
            Assert.IsNotNull(customs);
            foreach (var c in customs)
            {
                Assert.AreEqual("12", c.CustomAge);
            }
        }
        [TestMethod]
        [DataRow("ddd")]
        public void SelectCustomByElement_Test_DataIsNull(string name)
        {
            CustomQuery customQuery = new CustomQuery();
            customQuery.CustomQueryName = name;
            List<Custom> customs = customService.SelectCustomByElement(customQuery).Result;
            foreach (var c in customs)
            {
                Assert.IsNull(c.CustomName);
            }
            
        }
        /// <summary>
        /// 测试更新
        /// </summary>
        [TestMethod]
        [DataRow("mack", "212", "男", "511303199209021123", "19012901232",8)]
        public void UpdateCustomById_Test_Success(string name, string age, string sex, string idcard, string phone,int id)
        {
            Custom custom = new Custom();
            custom.CustomName = name;
            custom.CustomAge = age;
            custom.CustomSex = sex;
            custom.CustomIdCrad = idcard;
            custom.CustomPhone = phone;
            string result =  customService.UpdateCustomById(custom, id).Result;
            Assert.AreEqual("修改顾客信息成功", result);
        }

        [TestMethod]
        [DataRow("mack", "212", "男", "511303199209021123", "19012901232", 9)]
        public void UpdateCustomById_Test_Faile(string name, string age, string sex, string idcard, string phone, int id)
        {
            Custom custom = new Custom();
            custom.CustomName = name;
            custom.CustomAge = age;
            custom.CustomSex = sex;
            custom.CustomIdCrad = idcard;
            custom.CustomPhone = phone;
            string result = customService.UpdateCustomById(custom, id).Result;
            Assert.AreEqual("修改顾客信息失败，用户不存在或网络连接出现问题", result);
        }

        [TestMethod]
        [DataRow(null, "212", "男", "511303199209021123", "19012901232", 9)]
        public void UpdateCustomById_Test_Faile2(string name, string age, string sex, string idcard, string phone, int id)
        {
            Custom custom = new Custom();
            custom.CustomName = name;
            custom.CustomAge = age;
            custom.CustomSex = sex;
            custom.CustomIdCrad = idcard;
            custom.CustomPhone = phone;
            string result = customService.UpdateCustomById(custom, id).Result;
            Assert.AreEqual("姓名不能为空", result);
        }
        /// <summary>
        /// 测试删除
        /// </summary>
       
        [TestMethod]
        [DataRow(12)]
        //[DataRow(9)]
        public void DeleteById_Test(int id)
        {
            string result =  customService.DeleteById(id).Result;
            Assert.AreEqual("删除失败，用户不存在或网络连接出现问题", result);
        }

    }
}