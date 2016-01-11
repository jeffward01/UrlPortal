using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BOL;

namespace BLL
{
    public class CategoryBs
    {
        private CategoryDb objDb;

        public CategoryBs()
        {
            objDb = new CategoryDb();
        }

        public IEnumerable<tbl_Category> GetAll()
        {
            return objDb.GetAll();
        }

        public tbl_Category GetById(int id)
        {
            return objDb.GetByID(id);
        }

        public void Insert(tbl_Category url)
        {
            objDb.Insert(url);
        }

        public void Delete(int id)
        {
            objDb.Delete(id);
        }

        public void Update(tbl_Category url)
        {
            objDb.Update(url);
        }
    }
}