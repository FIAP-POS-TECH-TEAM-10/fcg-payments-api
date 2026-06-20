using Fiap.FCGames.Payments.Api.Controllers.Shared;
using Fiap.FCGames.Payments.Application.Queries.BuscarPagamento;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.FCGames.Payments.Api.Controllers;

[ApiController]
[Route("pagamentos")]
public class PagamentosController : ApiControllerBase<PagamentosController>
{
    public PagamentosController(ISender sender, ILogger<PagamentosController> logger) : base(sender, logger) { }

    [HttpGet("{orderId:guid}")]
    [Authorize]
    public async Task<IActionResult> BuscarAsync(Guid orderId, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(new BuscarPagamentoQuery(orderId), cancellationToken);
        return result is null ? NotFound() : Ok(result);
    }
}
