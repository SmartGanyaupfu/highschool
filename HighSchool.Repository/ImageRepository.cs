using System;
using HighSchool.Contracts;
using HighSchool.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace HighSchool.Repository
{
    public class ImageRepository : GenericRepositoryBase<Image>, IImageRepository
    {

        public ImageRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public void CreateImagesAsync(List<Image> images)
        {
            foreach (var image in images)
            {
                Create(image);
            }

        }

        public async void DeleteImageAsync(Image image)
        {
           // var imageToDelete = await FindByCondition(i => i.ImageId.Equals(image.ImageId), true).SingleOrDefault();
            Delete(image);
        }

      /*  public async Task<PagedList<Image>> GetAllImagesAsync(RequestParameters requestParameters, bool trackChanges)
        {
            var images = await FindAll(trackChanges).OrderByDescending(p => p.DateCreated).ToListAsync();

            return PagedList<Image>.ToPagedList(images, requestParameters.PageNumber, requestParameters.PageSize);
        }*/

        public async Task<Image> GetImageByIdAsync(int imageId, bool trackChanges)
        {
            return await FindByCondition(i => i.ImageId.Equals(imageId), trackChanges).SingleOrDefaultAsync();
        }

        public void UpdateImageAsync(Image image)
        {
            Update(image);
        }
    }
}

