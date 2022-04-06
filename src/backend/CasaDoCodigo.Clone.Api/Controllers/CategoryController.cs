using CasaDoCodigo.Clone.Api.Dtos;
using CasaDoCodigo.Clone.Domain.Interfaces;
using CasaDoCodigo.Clone.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Clone.Api.Controllers;

[Route("api/[controller]")]
public class CategoryController : MainController
{
    private readonly ICategoryService _categoryService;

    public CategoryController(INotifier notifier, ICategoryService categoryService) : base(notifier)
    {
        _categoryService = categoryService;
    }

    [HttpPost]
    public async Task<ActionResult> Create(CategoryDto categoryDto)
    {
        var category = categoryDto.ToModel();

        await _categoryService.CreateCategoryAsync(category);

        return CustomResponse();
    }
}
