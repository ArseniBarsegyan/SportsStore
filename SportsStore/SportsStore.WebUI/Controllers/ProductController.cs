using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using System.Linq;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        //Ninject будет внедрять зависимость для хранилища товаров,
        //когда будет создавать экземпляр класса контроллеров
        private IProductRepository repository;
        //4 товара на странице
        public int PageSize = 4;
        public ProductController(IProductRepository productRepository)
        {
            repository = productRepository;
        }

        public ViewResult List(int page = 1)
        {
            return View(repository.Products
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize));
        }
    }
}