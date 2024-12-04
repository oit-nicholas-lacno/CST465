using Lab8.DataObjects;
using Microsoft.Extensions.Caching.Memory;
using System.Runtime.CompilerServices;

namespace Lab8.Repositories
{
    public class CachingDbImageRepository : DbImageRepository, IImageRepository
    {
        private readonly IMemoryCache _Cache;
        private const string _CacheKey = "ImageList";

        public CachingDbImageRepository(IMemoryCache cache, IConfiguration config) : base(config)
        {
            _Cache = cache;
        }
        public override List<ImageObject> GetImages()
        {
            List<ImageObject>? imgList = _Cache.Get<List<ImageObject>>(_CacheKey);
            if (imgList == null)
            {
                imgList = base.GetImages();
                _Cache.Set(_CacheKey, imgList);
            }

            return imgList;
        }
        public override void SaveImage(ImageObject image)
        {
            base.SaveImage(image);
            _Cache.Remove(_CacheKey);
        }
    }
}
