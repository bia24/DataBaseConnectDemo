using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using DataBaseTest.Model;

namespace DataBaseTest.Mapping
{
    class TestUserMap:ClassMap<TestUser>
    {
        public TestUserMap()
        {
            Id(x=>x.Id).Column("Id");//x为lambda表达式的参数，代表testuser对象；
            //将x.id设置为数据库表中的主键
            //并对应数据库中的“Id”列
            Map(x => x.Username).Column("username");
            Map(x => x.Password).Column("password");
            Map(x => x.Age).Column("age");
            Table("testuser");
        }
    }
}
