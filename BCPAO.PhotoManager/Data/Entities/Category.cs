namespace BCPAO.PhotoManager.Data
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreateDate { get; set; }
        public string CreatedBy { get; set; }
        public string ChangeDate { get; set; }
        public string ChangedBy { get; set; }
        public string Status { get; set; }
    }
}
