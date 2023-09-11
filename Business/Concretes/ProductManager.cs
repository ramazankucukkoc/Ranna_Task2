using Business.Abstarcts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.Rules;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        ProductBusinessRules rules;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
            rules =new ProductBusinessRules(_productDal);
        }
    
        public void Add(CreateProductRequest createProductRequest)
        {
            Product product = new Product
            {
                Name = createProductRequest.Name,
                Description = createProductRequest.Description,
                UnitPrice = createProductRequest.UnitPrice,
                CategoryId = createProductRequest.CategoryId,
                CreatedDate = DateTime.UtcNow,
            };
            _productDal.Add(product);
        }

        public void Delete(DeleteProductRequest deleteProductRequest)
        {
            rules.ProdcutIsExists(deleteProductRequest.Id);
            Product product = _productDal.Get(p => p.Id == deleteProductRequest.Id);
            _productDal.Delete(product);
        }

        public List<GetProductResponse> GetAll()
        {
            List<Product> products = _productDal.GetAllWithCategory().ToList();

            List<GetProductResponse> getProductResponses = new List<GetProductResponse>();

            foreach (Product product in products)
            {
                GetProductResponse getProductResponse = new GetProductResponse();
                getProductResponse.Name = product.Name;
                getProductResponse.Description = product.Description;
                getProductResponse.UnitPrice = product.UnitPrice;
                getProductResponse.Id = product.Id;
                getProductResponse.CategoryId = product.CategoryId;
                getProductResponse.CategoryName = product.Category.Name;

                getProductResponses.Add(getProductResponse);
            }

            return getProductResponses;
        }

        public List<GetProductResponse> GetAll(string productName)
        {
            List<Product> products =
                           _productDal.GetAllWithCategory(productName).ToList();

            List<GetProductResponse> getProductResponses = new List<GetProductResponse>();

            foreach (Product product in products)
            {
                GetProductResponse getProductResponse = new GetProductResponse();
                getProductResponse.Name = product.Name;
                getProductResponse.Description = product.Description;
                getProductResponse.UnitPrice = product.UnitPrice;
                getProductResponse.Id = product.Id;
                getProductResponse.CategoryId = product.CategoryId;
                getProductResponse.CategoryName = product.Category.Name;

                getProductResponses.Add(getProductResponse);
            }

            return getProductResponses;
        }

        public void Update(UpdateProductRequest updateProductRequest)
        {
            rules.ProdcutIsExists(updateProductRequest.Id);
            Product product =_productDal.Get(p=>p.Id == updateProductRequest.Id);
            product.UnitPrice = updateProductRequest.UnitPrice;
            product.Description=updateProductRequest.Description;
            product.CategoryId=updateProductRequest.CategoryId;
            product.Name =updateProductRequest.Name;
            _productDal.Update(product);

        }
    }
}
