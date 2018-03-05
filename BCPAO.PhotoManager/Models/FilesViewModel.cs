using System.Collections.Generic;

namespace BCPAO.PhotoManager.Models
{
   public class FileDetails
   {
      public string Name { get; set; }
      public string Path { get; set; }
      public string Url { get; set; }
   }

   public class FilesViewModel
   {
      public List<FileDetails> Files { get; set; } = new List<FileDetails>();
   }
}
