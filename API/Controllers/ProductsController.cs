using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public ProductsController(IProductRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        // private readonly IGenericRepository<Product> _productsRepo;
        // private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        // private readonly IGenericRepository<ProductType> _productTypeRepo;
        // public ProductsController(
        //     IGenericRepository<Product> productsRepo, 
        //     IGenericRepository<ProductBrand> productBrandRepo,
        //     IGenericRepository<ProductType> productTypeRepo)
        // {
        //     _productsRepo = productsRepo;
        //     _productBrandRepo = productBrandRepo;
        //     _productTypeRepo = productTypeRepo;
        // }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync();

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);

            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpGet("brand")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _repo.GetProductBrandsAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _repo.GetProductTypesAsync());
        }
    }
}