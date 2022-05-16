using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_Framework.Infrastructure;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
   public class ProductCategoryRepository: RepositoryBase<long, ProductCategory> , IProductCategoryRepository
   {
       private readonly ShopContext _context;

       public ProductCategoryRepository(ShopContext context): base(context)
       {
           _context = context;
       }

      

        public List<ProductCategory> GetAll()
        {
            return _context.ProductCategories.ToList();
        }

       

        public EditProductCategory GetDetails(long id)
        {
            return _context.ProductCategories.Select(x => new EditProductCategory()
            {
                Id= x.Id,
                Name = x.Name,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescriptions = x.MetaDescriptions,
                //Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug

            }).FirstOrDefault(x => x.Id==id);

        }

        public string GetSlugById(long id)
        {
            return _context.ProductCategories
                .Select(x => new {x.Id, x.Slug})
                .FirstOrDefault(x => x.Id == id).Slug;
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _context.ProductCategories.Select(x => new ProductCategoryViewModel
                {
                    Id = x.Id,
                    Name = x.Name
                }
                ).ToList();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _context.ProductCategories.Select(x => new ProductCategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name,
                CreationDate = x.CreationDate.ToFarsi(),
                Picture = x.Picture,
                ProductsCount = x.Products.Count

            });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            return query.OrderByDescending(x => x.Id).ToList();

        }
    }
}
