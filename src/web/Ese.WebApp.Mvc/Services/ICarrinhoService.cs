using System;
using System.Threading.Tasks;
using Ese.WebApp.Mvc.Models;

namespace Ese.WebApp.Mvc.Services
{
    public interface ICarrinhoService
    {
        Task<CarrinhoViewModel> ObterCarrinho();
        Task<ResponseResultViewModel> AdicionarItemCarrinho(ItemProdutoViewModel produto);
        Task<ResponseResultViewModel> AtualizarItemCarrinho(Guid produtoId, ItemProdutoViewModel produto);
        Task<ResponseResultViewModel> RemoverItemCarrinho(Guid produtoId);
    }
}
