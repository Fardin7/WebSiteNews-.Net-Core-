using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Service.Interface;
using Model;
using DAL;
using Microsoft.AspNetCore.Http;
namespace Business
{
    public class FileManagement
    {
       // public static FileManagement _fileManagement;
        public bool delete { get; set; }
        public int FileId { get; set; }
        public int NewsId { get; set; }
        public  string Name { get; set; }
        public string Type { get; set; }
        public int Size { get; set; }
        public static string Address { get; set; }
        public static IFormFile File { get; set; }

        public FileManagement()
        {

        }

        //public static void UploadFile(string type, string name, int size, string address, IFormFile file,int fileid=0)
        //{
        //    if (_fileManagement == null)
        //    {
        //        _fileManagement = new FileManagement();
        //    }
        //    _fileManagement.Name = name;
        //    _fileManagement.Type = type;
        //    _fileManagement.Size = size;
        //    _fileManagement.Address = address;
        //    _fileManagement.File = file;
        //    if (_fileManagement.FileId==0)
        //    {
        //        _fileManagement.FileId = fileid;
        //    }
           
        //}
        // public static void InsertFile(News news, INewsFileService newsFileService)
        //{
        //    if (_fileManagement != null && _fileManagement.FileId == 0)
        //    {

        //      //  _fileManagement.File.CopyTo(_fileManagement.Address);
        //        var newsfileid = new NewsFile()
        //        {
        //            Name = _fileManagement.Name,
        //            NewsId = news.Id,
        //            Type = _fileManagement.Type,
        //            Size = _fileManagement.Size,
        //            UploadDate = DateTime.Now

        //        };
        //        newsFileService.Insert(newsfileid);
        //        _fileManagement = null;
        //        //_fileManagement.FileId = newsfileid.Id;
        //        //_fileManagement.File = null;
        //    }
        //    else if (_fileManagement != null && _fileManagement.FileId != 0 && _fileManagement.File!=null)
        //    {
                
        //        //_fileManagement.File.SaveAs(_fileManagement.Address);
        //        newsFileService.Update(new NewsFile()
        //        {
        //            Id=_fileManagement.FileId,
        //            Name = _fileManagement.Name,
        //            NewsId = news.Id,
        //            Type = _fileManagement.Type,
        //            Size = _fileManagement.Size,
        //            UploadDate = DateTime.Now

        //        });
        
        //    }
            
        //}
        
        //public static void DeleteFile(INewsFileService newsFileService)
        //{
        //    System.IO.File.Delete(_fileManagement.Address);
        //    newsFileService.Delete(_fileManagement.FileId);
        //    _fileManagement = null;
        //}

        }

    }

