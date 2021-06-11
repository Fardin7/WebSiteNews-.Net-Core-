using System;

namespace Model
{
   public class NewsFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public DateTime UploadDate { get; set; }
        public int NewsId { get; set; }
        public virtual News News { get; set; }
    }

}
