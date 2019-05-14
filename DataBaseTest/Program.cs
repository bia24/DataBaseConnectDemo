using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseTest.Utils;
using DataBaseTest.Model;

namespace DataBaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestUserUtils testUser = new TestUserUtils();
            Console.WriteLine("全表输出===>");
            IList<TestUser> ans= testUser.GetAllUser();
            foreach(var t in ans){
                Console.WriteLine(t.Id + " " + t.Username + " " + t.Password + " " + t.Age);
            }
            Console.WriteLine("按照username查找输出===>");
            ans = testUser.GetUserByName("bia");
            foreach (var t in ans)
            {
                Console.WriteLine(t.Id + " " + t.Username + " " + t.Password + " " + t.Age);
            }
            //Console.WriteLine("添加user===>");
            //TestUser n1 = new TestUser();
            //n1.Username = "yyf"; n1.Password = "hhhh"; n1.Age = 58;
            //int id = testUser.AddUser(n1);
            //Console.WriteLine("新user.id:" + id);
            Console.WriteLine("按照id删除===>");
            testUser.DeleteUserById(15);
            Console.WriteLine("修改user===>");
            TestUser n2 = new TestUser();
            n2.Username = "baoge"; n2.Password = "bbbb"; n2.Age = 4444;
            n2.Id = 6;
            testUser.UpdateUser(n2);
            Console.ReadKey();
        }
    }
}
