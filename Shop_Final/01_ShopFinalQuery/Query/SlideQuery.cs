using System.Collections.Generic;
using System.Linq;
using _01_ShopFinalQuery.Contracts.Slide;
using ShopManagement.Infrastructure.EFCore;

namespace _01_ShopFinalQuery.Query
{
    public class SlideQuery:ISlideQuery
    {
        private readonly ShopContext _shopContext;

        public SlideQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<SlideQueryModel> GetSlide()
        {
            return _shopContext.Slides
                .Where(x => x.IsRemoved == false)
                .Select(x => new SlideQueryModel
                {
                    Picture = x.Picture,
                    PictureAlt =x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    BtnText = x.BtnText,
                    Heading = x.Heading,
                    Link = x.Link,
                    Text = x.BtnText,
                    Title = x.Title

                }).ToList();
        }
    }
}
