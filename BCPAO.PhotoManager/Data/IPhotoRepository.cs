using System;
using System.Collections.Generic;

namespace BCPAO.PhotoManager.Data
{
   public interface IPhotoRepository : IDisposable
    {
        IEnumerable<Photo> GetPhotos();
        Photo GetPhoto(int photoId);
        void AddPhoto(Photo photo);
        void UpdatePhoto(Photo photo);
        void DeletePhoto(int photoId);
        bool PhotoExists(int photoId);
        IEnumerable<Photo> GetPhotosForProperty(int propertyId);
        void Save();
    }
}
