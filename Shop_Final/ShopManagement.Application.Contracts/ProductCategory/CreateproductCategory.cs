using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using _0_Framework.Application;

namespace ShopManagement.Application.Contracts.ProductCategory
{
    public class CreateProductCategory
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)] 
        public string Name { get; set; }
        
        public string Description { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }

        
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Keywords { get; set; }

        
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string MetaDescriptions { get; set; }

        
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Slug { get; set; }
    }


}
