using KuasCore.Models;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Dao.Mapper
{
    class GoodsRowMapper : IRowMapper<Goods>
    {
        public Goods MapRow(IDataReader dataReader, int rowNum)
        {
            Goods target = new Goods();

            target.id = dataReader.GetString(dataReader.GetOrdinal("id"));
            target.name = dataReader.GetString(dataReader.GetOrdinal("name"));
            target.price = dataReader.GetInt32(dataReader.GetOrdinal("price"));
            target.num = dataReader.GetInt32(dataReader.GetOrdinal("num"));
            target.describe = dataReader.GetString(dataReader.GetOrdinal("describe"));
            target.time = dataReader.GetDateTime(dataReader.GetOrdinal("time"));
            target.type = dataReader.GetString(dataReader.GetOrdinal("type"));
            return target;
        }
    }
}
