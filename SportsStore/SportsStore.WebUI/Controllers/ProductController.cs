using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        //Ninject будет внедрять зависимость для хранилища товаров,
        //когда будет создавать экземпляр класса контроллеров
        private readonly IProductRepository _repository;
        //4 товара на странице
        public int PageSize = 4;
        public ProductController(IProductRepository productRepository)
        {
            _repository = productRepository;
        }

        public ViewResult List(int page = 1)
        {
            /*return View(repository.Products
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize));
                */
            //Передает объект ProductListViewModel в качестве данных модели в представление
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = _repository.Products
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = _repository.Products.Count()
                }
            };
            return View(model);
        }
    }
}