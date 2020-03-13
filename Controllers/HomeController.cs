using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tree.Models;

namespace Tree.Controllers
{
    public class HomeController : Controller
    {

        private TreeDB _context;
        
     
        public HomeController()
        {
            _context = new TreeDB();
          
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpGet]
        public ActionResult Index(int? id)
        {
           
            var items = _context.NodeEntities.Where(x => x.ParentId == id);

            ViewBag.ParentId = id;
            return View(items);
        }
        public ActionResult Wstecz(int? parentId)
        {
            var item = _context.NodeEntities.Single(x => x.Id == parentId);
            return RedirectToAction("Index", new { id = item.ParentId });
        }
        
        [HttpPost]
        public ActionResult Save(Node node, int? parentId)
        {
            if (node.Id == 0)
            {
                node.ParentId = parentId;
                _context.NodeEntities.Add(node);
            }
                
            else
            {
                Node nodeInDb = _context.NodeEntities.Single(n => n.Id == node.Id);
                nodeInDb.Name = node.Name;
                
            }
            _context.SaveChanges();

            return RedirectToAction("Index", new { id = node.ParentId });
        }

        private void Remove(Node node)
        {
           
            var listOfNodes = _context.NodeEntities.Where(a => a.ParentId == node.Id);
            if (listOfNodes != null)
                foreach (var node3 in listOfNodes)
                    Remove(node3);
            
            _context.NodeEntities.Remove(node);
        }
        [HttpPost]
        public HttpStatusCodeResult Delete(int id)
        {
            Node nodeInDb = _context.NodeEntities.Single(n => n.Id == id);

            Remove(nodeInDb);
            //_context.NodeEntities.Remove(nodeInDb);
            
            _context.SaveChanges();

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
            //return RedirectToAction("Index", new { nodeInDb.ParentId });
            
        }
        public PartialViewResult NodeForm(int? id)
        {
            Node node = _context.NodeEntities.FirstOrDefault(x => x.Id == id);

            return PartialView("_NodeForm", node);
  
        }

    }
}