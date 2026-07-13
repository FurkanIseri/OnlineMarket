using System.Data.Common;
using AutoMapper;

using Entities.Dtos;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore.Metadata;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateOneProduct(ProductDtoForInsertion p)
        {
            Product product = _mapper.Map<Product>(p);
            _manager.Product.Create(product);
            _manager.Save();
        }

        public void DeleteOneProduct(int id)
        {
            Product? product = GetOneProduct(id,true);
            if(product is not null)
            {
                _manager.Product.DeleteOneProduct(product);
                _manager.Save();
            }
        }

        public IEnumerable<Product> GetAllProducts(bool trackchanges)
        {
            return _manager.Product.GetAllProducts(trackchanges);
        }

        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameter p)
        {
            return _manager.Product.GetAllProductsWithDetails(p);
        }

        public IEnumerable<Product> GetLastestProducts(int n, bool trackchanges)
        {
            return _manager
            .Product
            .FindAll(trackchanges)
            .OrderByDescending(prd => prd.ProductId)
            .Take(n);
        }

        public Product? GetOneProduct(int id,bool trackchanges)
        {
            var product = _manager.Product.GetOneProduct(id,trackchanges);
            if (product is null)
            {
                throw new Exception("Ürün Bulunumadı");
            }
            return product;
        }

        public ProductDtoForUpdate GetOneProductForUpdate(int id, bool trackchanges)
        {
            var product = GetOneProduct(id,trackchanges);
            var productDto = _mapper.Map<ProductDtoForUpdate>(product);
            return productDto;
        }

        public IEnumerable<Product> GetShowcaseProducts(bool trackchanges)
        {
            return _manager.Product.GetShowcaseProducts(trackchanges);
        }

        public void UpdateOneProduct(ProductDtoForUpdate p)
        {
            Product product = _mapper.Map<Product>(p);
            _manager.Product.UpdateOneProduct(product);
            _manager.Save();
        }
    }
}