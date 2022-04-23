using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlayPedidos.API.ViewModel;
using PlayPedidos.Domain.Entities;
using PlayPedidos.Domain.Interfaces.Repositories;

namespace PlayPedidos.API.Controllers
{
	[Route("api/v1/products")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IProductRepository _productRepository;

		public ProductController(IMapper mapper, IProductRepository productRepository)
		{
			_mapper = mapper;
			_productRepository = productRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var products = await _productRepository.Get();

			var productsViewModel = _mapper.Map<IEnumerable<ProductViewModel>>(products);

			return Ok(productsViewModel);
		}

		[HttpGet("{id}", Name = nameof(GetById))]
		public async Task<IActionResult> GetById(int id)
		{
			var product = await _productRepository.GetSingle(x => x.ID == id);

			var viewModel = _mapper.Map<ProductViewModel>(product);

			if (viewModel == null)
				NotFound();

			return Ok(viewModel);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] ProductPostViewModel productViewModel)
		{
			var product = _mapper.Map<Product>(productViewModel);

			if (product == null)
				return BadRequest();

			if (!product.IsValid())
				return BadRequest(_mapper.Map<ErrorViewModel>(product.GetErrors()));

			await _productRepository.Add(product);

			var newProductViewModel = _mapper.Map<ProductViewModel>(product);
			return new CreatedAtRouteResult(nameof(GetById), new { id = newProductViewModel.ID }, newProductViewModel);
		}

		[HttpPut("{id}")]
		[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
		public async Task<IActionResult> PutById(int id, [FromBody] ProductPutViewModel productViewModel)
		{
			if (id != productViewModel.ID)
				return BadRequest();

			var product = _mapper.Map<Product>(productViewModel);

			if (!product.IsValid())
				return BadRequest(_mapper.Map<ErrorViewModel>(product.GetErrors()));

			await _productRepository.Edit(product);

			var editedProductViewModel = _mapper.Map<ProductViewModel>(product);
			return Ok(editedProductViewModel);
		}

		[HttpDelete]
		public async Task<IActionResult> DeleteById(int id)
		{
			var product = await _productRepository.GetSingle(x => x.ID == id);

			if (product == null)
				return BadRequest();

			await _productRepository.Delete(product);

			return NoContent();
		}
	}
}
