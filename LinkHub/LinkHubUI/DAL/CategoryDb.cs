using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoryDb
    {
        private LinkHubDbEntities db;

        public CategoryDb()
        {
            db = new LinkHubDbEntities();
        }

        public IEnumerable<tbl_Category> GetAll()
        {
            return db.tbl_Category.ToList();
        }

        public tbl_Category GetByID(int id)
        {
            return db.tbl_Category.Find(id);
        }

        public void Insert(tbl_Category url)
        {
            db.tbl_Category.Add(url);
            Save();
        }

        public void Delete(int id)
        {
            tbl_Category category = db.tbl_Category.Find(id);
            db.tbl_Category.Remove(category);
            Save();
        }

        public void Update(tbl_Category category)
        {
            db.Entry(category).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}