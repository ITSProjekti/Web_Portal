using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPortal.Models;
using WebPortal.ViewModels;


namespace WebPortal.ViewModels
{
    public class MaterijalViewModel
    {
        //public IEnumerable<MaterijalModel> mater { get; set; }

        public string materijalNaziv { get; set; }
        public HttpPostedFileBase File { get; set; }
    }
}