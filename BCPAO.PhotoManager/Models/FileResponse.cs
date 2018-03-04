using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCPAO.PhotoManager.Models
{
    // JSON file response from the server
    // https://github.com/blueimp/jQuery-File-Upload/wiki/Setup#using-jquery-file-upload-ui-version-with-a-custom-server-side-upload-handler
    public class FileResponse
    {
        public string Name { get; set; }
        public long Size { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public string DeleteUrl { get; set; }
        public string DeleteType { get; set; }
        public string Error { get; set; }
    }
}
