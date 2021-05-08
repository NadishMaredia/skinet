using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        
        public async Task<IReadOnlyList<Product>> GetProductsAsync(string sort = null, 
            int brandId = 0, int typeId = 0, string name = null)
        {

            if(sort == "priceDsc") 
            {
                //Filtering Type and brand
                if(typeId > 0 && brandId > 0) 
                {
                    return await _context.Products
                        .Include(p => p.ProductBrand)
                        .Include(p => p.ProductType)
                        .OrderBy(p => p.Name)
                        .Where(p => p.ProductTypeId == typeId && p.ProductBrandId == brandId)
                        .ToListAsync();
                }
                else if(brandId > 0)
                {
                    return await _context.Products
                        .Include(p => p.ProductBrand)
                        .Include(p => p.ProductType)
                        .OrderBy(p => p.Name)
                        .Where(p => p.ProductBrandId == brandId)
                        .ToListAsync();
                }
                else if(typeId > 0)
                {
                    return await _context.Products
                        .Include(p => p.ProductBrand)
                        .Include(p => p.ProductType)
                        .OrderBy(p => p.Name)
                        .Where(p => p.ProductTypeId == typeId)
                        .ToListAsync();
                }

                return await _context.Products
                    .Include(p => p.ProductBrand)
                    .Include(p => p.ProductType)
                    .OrderByDescending(p => p.Price)
                    .ToListAsync();
            }
            else if(sort == "priceAsc")
            {
                //Filtering Type and brand
                if(typeId > 0 && brandId > 0) 
                {
                    return await _context.Products
                        .Include(p => p.ProductBrand)
                        .Include(p => p.ProductType)
                        .OrderBy(p => p.Name)
                        .Where(p => p.ProductTypeId == typeId && p.ProductBrandId == brandId)
                        .ToListAsync();
                }
                else if(brandId > 0)
                {
                    return await _context.Products
                        .Include(p => p.ProductBrand)
                        .Include(p => p.ProductType)
                        .OrderBy(p => p.Name)
                        .Where(p => p.ProductBrandId == brandId)
                        .ToListAsync();
                }
                else if(typeId > 0)
                {
                    return await _context.Products
                        .Include(p => p.ProductBrand)
                        .Include(p => p.ProductType)
                        .OrderBy(p => p.Name)
                        .Where(p => p.ProductTypeId == typeId)
                        .ToListAsync();
                }
                return await _context.Products
                    .Include(p => p.ProductBrand)
                    .Include(p => p.ProductType)
                    .OrderBy(p => p.Price)
                    .ToListAsync();
            }

            //Filtering Type and brand
            if(typeId > 0 && brandId > 0) 
            {
                return await _context.Products
                    .Include(p => p.ProductBrand)
                    .Include(p => p.ProductType)
                    .OrderBy(p => p.Name)
                    .Where(p => p.ProductTypeId == typeId && p.ProductBrandId == brandId)
                    .ToListAsync();
            }
            else if(brandId > 0)
            {
                return await _context.Products
                    .Include(p => p.ProductBrand)
                    .Include(p => p.ProductType)
                    .OrderBy(p => p.Name)
                    .Where(p => p.ProductBrandId == brandId)
                    .ToListAsync();
            }
            else if(typeId > 0)
            {
                return await _context.Products
                    .Include(p => p.ProductBrand)
                    .Include(p => p.ProductType)
                    .OrderBy(p => p.Name)
                    .Where(p => p.ProductTypeId == typeId)
                    .ToListAsync();
            }

            //Filtering name
            if (name != null)
            {
                return await _context.Products
                    .Include(p => p.ProductBrand)
                    .Include(p => p.ProductType)
                    .Where(p => p.Name.ToLower().Contains(name.ToLower()))
                    .ToListAsync();
            }
            

            return await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .OrderBy(p => p.Name)
                .ToListAsync();
            
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
            .Include(p=>p.ProductType)
            .Include(p => p.ProductBrand)
            .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}