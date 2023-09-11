using Business.Dtos.Requests;
using Business.Dtos.Responses;

namespace Business.Abstarcts
{
    public interface IProductService
    {
        List<GetProductResponse> GetAll();
        List<GetProductResponse> GetAll(string productName);

        void Add(CreateProductRequest createProductRequest);

        void Delete(DeleteProductRequest deleteProductRequest);

        void Update(UpdateProductRequest updateProductRequest);
    }
}
