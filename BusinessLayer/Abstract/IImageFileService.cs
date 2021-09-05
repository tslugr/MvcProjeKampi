using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IImageFileService
    {
        List<ImageFile> GetList();
        void ImageFileAddBL(ImageFile imageFile);
        About GetByID(int id);
        void ImageFileDelete(ImageFile imageFile);
        void ImageFileUpdate(ImageFile imageFile);
    }
}
