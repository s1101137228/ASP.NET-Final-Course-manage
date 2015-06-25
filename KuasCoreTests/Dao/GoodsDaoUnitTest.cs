using KuasCore.Dao;
using KuasCore.Models;
using KuasCore.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCoreTests.Dao
{
    [TestClass]
    public class GoodsDaoUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCorePointcut.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public IGoodsDao GoodsDao { get; set; }

        [TestMethod]
        public void TestGoodsDao_AddGoods()
        {
            Goods goods = new Goods();
            goods.id = "A001";
            goods.name = "舒跑";
            goods.price= 25;
            goods.count = 40;
            goods.describe = "發燒喝舒跑";
            goods.time = new DateTime(2015,06,26);
            goods.type = "飲料";
            GoodsDao.AddGoods(goods);

            Goods dbGoods = GoodsDao.GetGoodsByName(goods.name);
            Assert.IsNotNull(dbGoods);
            Assert.AreEqual(goods.name, dbGoods.name);

            Console.WriteLine("編號為 = " + dbGoods.id);
            Console.WriteLine("名稱為 = " + dbGoods.name);
            Console.WriteLine("價格為 = " + dbGoods.price);
            Console.WriteLine("數量為 = " + dbGoods.count);
            Console.WriteLine("描述為 = " + dbGoods.describe);
            Console.WriteLine("時間為 = " + dbGoods.time);
            Console.WriteLine("種類為 = " + dbGoods.type);
            GoodsDao.DeleteGoods(dbGoods);
            dbGoods = GoodsDao.GetGoodsByName(goods.name);
            Assert.IsNull(dbGoods);
        }

    }
}
