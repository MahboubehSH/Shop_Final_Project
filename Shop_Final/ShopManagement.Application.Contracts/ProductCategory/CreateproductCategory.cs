using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public class CreateproductCategory
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Keywords { get; set; }
        public string MetaDescriptions { get; set; }
        public string Slug { get; set; }
    }


}
