using KuasCore.Dao;
using KuasCore.Dao.Impl;
using KuasCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Services.Impl
{
    public class GoodsService : IGoodsService
    {
        public IGoodsDao GoodsDao { get; set; }

        public Goods AddGoods(Goods goods)
        {
            GoodsDao.AddGoods(goods);
            return GetGoodsByName(goods.name);
        }

        public void UpdateGoods(Goods goods)
        {
            GoodsDao.UpdateGoods(goods);
        }


        public void DeleteGoods(Goods goods)
        {
            goods = GoodsDao.GetGoodsByName(goods.name);

            if (goods != null)
            {
                GoodsDao.DeleteGoods(goods);
            }
        }

        public IList<Goods> GetAllGoods()
        {
            return GoodsDao.GetAllGoods();
        }

        public Goods GetGoodsByName(string name)
        {
            return GoodsDao.GetGoodsByName(name);
        }

        public Goods GetGoodsById(string id)
        {
            return GoodsDao.GetGoodsById(id);
        }
    }
}
