using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;
namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository repository;
        public int PageSize = 4;
        public ProductController(IProductsRepository productRepository)
        {
            repository = productRepository;
        }
        // GET: Product
        public ViewResult List(string category ,int page=1)

        {
            productsListViewModel model = new productsListViewModel
            {
                Products = repository.Products.Where(P => category == null || P.Category == category).OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize).Take(PageSize)
                 ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemPerPage = PageSize,
                 
                    TotalItem = category==null?
                    repository.Products.Count():
                    repository.Products.Where(e=>e.Category==category).Count()
                },
                CurrentCategory = category
            };
            return View(model);

            //只能显示前面的四种产口品
         //return View(repository.Products.OrderBy(p=>p.ProductID).Skip((page-1)*PageSize).Take(PageSize));
        }
    }
}