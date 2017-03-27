using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootLegDemo.Models
{
    public class SupplierListModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string CompanyName { get; set; }
    }

    public class SupplierEntryModel : SupplierListModel
    {
        public List<SelectListItem> SupplierType { get; set; }
        public int SupplierTypeId { get; set; }
    }
}