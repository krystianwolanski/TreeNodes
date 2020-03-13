using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Tree.Models
{
    public class Node
    {
        public int Id { get; set; }
        public String Name { get; set; }
        
        public Node Parent { get; set; }
        public int? ParentId { get; set; }
    }
}