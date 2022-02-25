using System;
using System.ComponentModel.DataAnnotations;

namespace MVCEcommerceWebSite.Data
{
    public class FileUpload
    {
        [Key]
        public long Id { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string OriginalFileName { get; set; }

        public long FileSize { get; set; }

       
        public bool isFeaturedImage { get; set; }
    }
}