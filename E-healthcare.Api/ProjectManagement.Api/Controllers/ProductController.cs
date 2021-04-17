using EHealthcare.Entities;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Data;
using ProjectManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManagement.Api.Controllers
{
    [ApiController]
    [Route("api/Product")]
    public class ProductController : BaseController<Product>
    {
        private IBaseRepository<Category> CatRepository { get; set; }
        public ProductController(IBaseRepository<Category> repository)
        {
            CatRepository = repository;
        }

        public override IActionResult Get(long? id)
        {
            Product product = new Product();
            if (id.HasValue && id > 0)
            {
                product = Repository.Get(id.Value);
            }
            product.Categories = CatRepository.Get();
            return Ok(product);
        }
    }
}
