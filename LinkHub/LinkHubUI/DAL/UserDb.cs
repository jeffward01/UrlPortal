﻿using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDb
    {
        private LinkHubDbEntities db;

        public UserDb()
        {
            db = new LinkHubDbEntities();
        }

        public IEnumerable<tbl_User> GetAll()
        {
            return db.tbl_User.ToList();
        }

        public tbl_User GetByID(int id)
        {
            return db.tbl_User.Find(id);
        }

        public void Insert(tbl_User url)
        {
            db.tbl_User.Add(url);
            Save();
        }

        public void Delete(int id)
        {
            tbl_User user = db.tbl_User.Find(id);
            db.tbl_User.Remove(user);
            Save();
        }

        public void Update(tbl_User category)
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