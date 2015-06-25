﻿using KuasCore.Models;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCore.Dao.Mapper
{
    class CourseRowMapper : IRowMapper<Course>
    {
        public Course MapRow(IDataReader dataReader, int rowNum)
        {
            Course target = new Course();

            target.Id = dataReader.GetString(dataReader.GetOrdinal("Course_ID"));
            target.Name = dataReader.GetString(dataReader.GetOrdinal("Course_Name"));
            target.Description = dataReader.GetString(dataReader.GetOrdinal("Course_Description"));

            return target;
        }
    }
}
