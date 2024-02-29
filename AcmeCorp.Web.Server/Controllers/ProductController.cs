using Microsoft.AspNetCore.Mvc;

namespace AcmeCorp.Web.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : Controller
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		//getall

		//getbyid
	}
}
