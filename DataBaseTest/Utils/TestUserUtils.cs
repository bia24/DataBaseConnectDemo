using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseTest.Model;
using NHibernate;

namespace DataBaseTest.Utils
{
    class TestUserUtils
    {
        public IList<TestUser> GetAllUser()
        {
            //using 语句在块结束的时候会释放资源
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var ans= session.QueryOver<TestUser>();
                    transaction.Commit();
                    return ans.List();
                }
            }
        }

        public IList<TestUser> GetUserByName(string username)
        {
            //using 语句在块结束的时候会释放资源
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    var ans = session.QueryOver<TestUser>().Where(x=>x.Username==username);
                    transaction.Commit();
                    return ans.List();
                }
            }
        }

        public int AddUser(TestUser user)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    int id= (int)session.Save(user);
                    transaction.Commit();
                    return id;
                }
            }
        }

        public void DeleteUserById(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    TestUser user = new TestUser();
                    user.Id = id;
                    try
                    {
                        session.Delete(user);//使用string query的话，要使用HQL语句
                        transaction.Commit();
                    }
                    catch (StaleStateException)
                    {
                        Console.WriteLine("指定id："+id+" 的数据不存在");
                    }
                }
            }
        }

        public void UpdateUser(TestUser user)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(user);
                        transaction.Commit();
                    }
                    catch (StaleStateException)
                    {
                        Console.WriteLine("指定id：" + user.Id + " 的数据不存在");
                    }
                }
            }
        }

    }
}
