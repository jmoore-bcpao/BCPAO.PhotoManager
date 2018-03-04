using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BCPAO.PhotoManager.Data
{
   public class PhotoRepository : IPhotoRepository, IDisposable
    {
        private readonly DatabaseContext _context;
        
        public PhotoRepository(DatabaseContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Photo> GetPhotosForProperty(int propertyId)
        {
            return _context.Photos.Where(p => p.PropertyId == propertyId).ToList();
        }

        public IEnumerable<Photo> GetPhotos()
        {
            return _context.Photos.ToList();
        }

        public Photo GetPhoto(int photoId)
        {
            var photo = _context.Photos.FirstOrDefault(p => p.PhotoId == photoId);
            return photo;
        }

        public void AddPhoto(Photo photo)
        {
            _context.Photos.Add(photo);
            _context.SaveChanges();
        }

        public void UpdatePhoto(Photo photo)
        {
            _context.Entry(photo).State = EntityState.Modified;
        }

        public void DeletePhoto(int photoId)
        {
            var photo = _context.Photos.Find(photoId);
            _context.Photos.Remove(photo);
        }

        public bool PhotoExists(int photoId)
        {
            return _context.Photos.Any(p => p.PhotoId == photoId);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
