using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Respositories
{
    public class CategoryRepository : ICategoryDal
    {
        Context c = new Context();
        public void Delete(Category t)
        {
            c.Remove(t);
            c.SaveChanges();
        }

        public Category GetByID(int id)
        {
            return c.Categories.Find(id);
        }

        public List<Category> GetListAll()
        {
            return c.Categories.ToList();
        }

        public void Insert(Category t)
        {
             c.Add(t);
            c.SaveChanges();
        }

        public void Update(Category t)
        {
            c.Update(t);
            c.SaveChanges();
        }
    }
}
