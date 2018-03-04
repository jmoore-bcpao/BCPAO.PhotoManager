using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BCPAO.PhotoManager.Models
{
    [Table("bcpao.WebBuildingPhotos")]
    public class BuildingPhoto
    {
        [Key]
        public int PhotoID { get; set; }
        public int PropertyID { get; set; }
        public int BuildingID { get; set; }
        public int BuildingSequence { get; set; }
        public string FilePath { get; set; }
        public byte[] ImageDate { get; set; }
        public int? ImageSize { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageData { get; set; }
        public bool MasterPhoto { get; set; }
        public bool FrontPhoto { get; set; }
        public bool? PublicPhoto { get; set; }
        public DateTime? DateUploaded { get; set; }
        public DateTime? LastDateTransferred { get; set; }
        public bool Active { get; set; }
    }
}