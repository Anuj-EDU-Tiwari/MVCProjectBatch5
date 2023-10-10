using MVCProjectBatch5.Db_conn;
using MVCProjectBatch5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectBatch5.Controllers
{
    public class HomeController : Controller
    {
        //read data
        public ActionResult Index()
        {
            List<Class1> emplist = new List<Class1>();
            cshar5batchEntities db = new cshar5batchEntities();
            var kt=db.tbl_Emp.ToList();
            foreach (var item in kt)
            {
                emplist.Add(new Class1()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    Mobile = item.Mobile,
                    Address = item.Address,
                    Sal = item.Sal,
                    Zipcode = item.Zipcode,

                });
            }
            return View(emplist);
        }
        //add data / create data
        [HttpGet]
        public ActionResult AddEmp()
        {
           

            return View();
        }
        //contains both add and update record
        [HttpPost]
        public ActionResult AddEmp(Class1 obj)
        {
            cshar5batchEntities db = new cshar5batchEntities();
            tbl_Emp objemp=new tbl_Emp();
            objemp.Id = obj.Id;
            objemp.Name = obj.Name;
            objemp.Email = obj.Email;
            objemp.Mobile = obj.Mobile;
            objemp.Address = obj.Address;
            objemp.Sal = obj.Sal;
            objemp.Zipcode = obj.Zipcode;
            objemp.Zipcode = obj.Zipcode;

            if (obj.Id == 0)
            {
                //add new record
                db.tbl_Emp.Add(objemp);
                db.SaveChanges();
            }
            else
            { 
                //update/edit new record
              db.Entry(objemp).State=System.Data.Entity.EntityState.Modified;
              db.SaveChanges();
            }
            
            return RedirectToAction("Index");
        }

        //edit data
        public ActionResult Edit(int Id)
        {
            Class1 emp = new Class1();
            cshar5batchEntities db = new cshar5batchEntities();
            var editdata = db.tbl_Emp.Where(a => a.Id == Id).First(); //gets data
            emp.Address = editdata.Address; // in these lines we give data to our model emp
            emp.Sal = editdata.Sal;
            emp.Zipcode = editdata.Zipcode;
            emp.Email = editdata.Email;
            emp.Mobile = editdata.Mobile;
            emp.Name = editdata.Name;
            emp.Id = Id;
            //return View("AddEmp",editdata); //earlier
            return View("AddEmp", emp); //updated
        }


        public ActionResult About()
        {
            

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //delete data
        public ActionResult Delete(int Id)
        {
            cshar5batchEntities db = new cshar5batchEntities();
            var deletedata = db.tbl_Emp.Where(x => x.Id == Id).First();
            //var deletedata = db.tbl_Emp.Where(x => x.Id == Id).First();
            db.tbl_Emp.Remove(deletedata);
            db.SaveChanges();
            

            return RedirectToAction("Index");
        }
    }
}