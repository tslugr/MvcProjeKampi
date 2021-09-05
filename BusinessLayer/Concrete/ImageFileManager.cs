using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imagefiledal;

        public ImageFileManager(IImageFileDal imagefiledal)
        {
            _imagefiledal = imagefiledal;
        }

        public About GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<ImageFile> GetList()
        {
        return _imagefiledal.List();
        }

        public void ImageFileAddBL(ImageFile imageFile)
        {
            throw new NotImplementedException();
        }

        public void ImageFileDelete(ImageFile imageFile)
        {
            throw new NotImplementedException();
        }

        public void ImageFileUpdate(ImageFile imageFile)
        {
            throw new NotImplementedException();
        }
    }
}
