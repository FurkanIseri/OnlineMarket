namespace Services.Contracts
{
    public interface IServicerManager
    {
        IProductService ProductService{get;}
        ICategoryService CategoryService{get;}
    }
}