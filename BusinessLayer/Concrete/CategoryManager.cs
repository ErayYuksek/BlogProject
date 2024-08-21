using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Respositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        EfCategoryRepository efCategoryRepository;

        public CategoryManager(EfCategoryRepository efCategoryRepository)
        {
            this.efCategoryRepository = efCategoryRepository;
        }

        public void CategoryAdd(Category category)
        {
            // Generic Repository den aldıgımız methotları kullancaz
            efCategoryRepository.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            efCategoryRepository.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            efCategoryRepository.Update(category);
        }

        public Category GetById(int id)
        {
            return efCategoryRepository.GetByID(id);

        }

        public List<Category> GetLlistt()
        {
            return efCategoryRepository.GetListAll();
        }
    }
}
