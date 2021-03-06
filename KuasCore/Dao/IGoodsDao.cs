﻿using KuasCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Dao
{
     public interface IGoodsDao
    {
         void AddGoods(Goods goods);

         void UpdateGoods(Goods goods);

         void DeleteGoods(Goods goods);

         IList<Goods> GetAllGoods();

         Goods GetGoodsByName(string name);

         Goods GetGoodsById(string id);

    }
}
