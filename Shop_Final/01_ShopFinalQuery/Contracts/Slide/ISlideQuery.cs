using System;
using System.Collections.Generic;
using System.Text;

namespace _01_ShopFinalQuery.Contracts.Slide
{
    public interface ISlideQuery
    {
        List<SlideQueryModel> GetSlide();
    }
}
