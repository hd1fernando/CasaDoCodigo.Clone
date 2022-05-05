using CasaDoCodigo.Clone.Api.Dtos;
using CasaDoCodigo.Clone.Domain.Interfaces;
using CasaDoCodigo.Clone.Domain.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Clone.Api.Controllers;

// CI: 3
[Route("api/[controller]")]
public class CategoryController : MainController
{
    // 1
    private readonly ICategoryService _categoryService;

    // 1
    public CategoryController(INotifier notifier, ICategoryService categoryService) : base(notifier)
    {
        _categoryService = categoryService;
    }

    // 1
    [HttpPost]
    public async Task<ActionResult> Create(CategoryDto categoryDto)
    {
        var category = categoryDto.ToModel();

        await _categoryService.CreateCategoryAsync(category);

        return CustomResponse();
    }
}
