using CasaDoCodigo.Clone.Api.Dtos;
using CasaDoCodigo.Clone.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Clone.Api.Controllers;

[Route("api/[controller]")]
public class PaymentController : MainController
{
    public PaymentController(INotifier notifier) : base(notifier)
    {
    }

    [HttpPost]
    public async Task<ActionResult> Create(PaymentDto paymentDto)
    {

        return CustomResponse();
    }
}
