using KuasCore.Dao.Base;
using KuasCore.Dao.Mapper;
using KuasCore.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Dao.Impl
{
    public class GoodsDao : GenericDao<Goods>, IGoodsDao
    {
        override protected IRowMapper<Goods> GetRowMapper()
        {
            return new GoodsRowMapper();
        }

        public void AddGoods(Goods goods)
        {
            string command = @"INSERT INTO goods (id, name, price , num , describe ,time , type ) VALUES (@id, @name, @price,@num,@describe,@time,@type);";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("id", DbType.String).Value = goods.id;
            parameters.Add("name", DbType.String).Value = goods.name;
            parameters.Add("price", DbType.Int32).Value = goods.price;
            parameters.Add("num", DbType.Int32).Value = goods.num;
            parameters.Add("describe", DbType.String).Value = goods.describe;
            parameters.Add("time", DbType.DateTime).Value = goods.time;
            parameters.Add("type", DbType.String).Value = goods.type;
            ExecuteNonQuery(command, parameters);
        }
        
        public void UpdateGoods(Goods goods)
        {
            string command = @"UPDATE goods SET name = @name, price = @price ,num = @num , describe = @describe , time = @time , type=@type WHERE id = @id;";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("id", DbType.String).Value = goods.id;
            parameters.Add("name", DbType.String).Value = goods.name;
            parameters.Add("price", DbType.Int32).Value = goods.price;
            parameters.Add("num", DbType.Int32).Value = goods.num;
            parameters.Add("describe", DbType.String).Value = goods.describe;
            parameters.Add("time", DbType.DateTime).Value = goods.time;
            parameters.Add("type", DbType.String).Value = goods.type;

            ExecuteNonQuery(command, parameters);
        }

        public void DeleteGoods(Goods goods)
        {
            string command = @"DELETE FROM goods WHERE id = @id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("id", DbType.String).Value = goods.id;

            ExecuteNonQuery(command, parameters);
        }
        
        public IList<Goods> GetAllGoods()
        {
            string command = @"SELECT * FROM goods ORDER BY id ASC";
            IList<Goods> goods = ExecuteQueryWithRowMapper(command);
            return goods;
        }

        public Goods GetGoodsByName(string name)
        {
            string command = @"SELECT * FROM goods WHERE name = @name";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("name", DbType.String).Value = name;

            IList<Goods> goods = ExecuteQueryWithRowMapper(command, parameters);
            if (goods.Count() > 0)
            {
                return goods[0];
            }

            return null;
        }

        public Goods GetGoodsById(string id)
        {
            string command = @"SELECT * FROM Goods WHERE id = @id";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("id", DbType.String).Value = id;

            IList<Goods> goods = ExecuteQueryWithRowMapper(command, parameters);
            if (goods.Count() > 0)
            {
                return goods[0];
            }

            return null;
        }
    }
}
