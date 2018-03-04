using BCPAO.PhotoManager.Data;
using System;
using System.Collections.Generic;

namespace BCPAO.PhotoManager.Models
{
    public class SearchFilterViewModel
    {
        public int? PhotoId { get; set; }
        public int? PropertyId { get; set; }
        public string UploadedBy { get; set; }
        public DateTime UploadedDateFrom { get; set; }
        public DateTime UploadedDateTo { get; set; }
        public DateTime ArchivedDateFrom { get; set; }
        public DateTime ArchivedDateTo { get; set; }
        public bool MasterPhoto { get; set; }
        public bool FrontPhoto { get; set; }
        public bool PublicPhoto { get; set; }
        public string Status { get; set; }
        public bool Active { get; set; }

        //public List<Photo> Photos { get; set; }
    }
}
