using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Challenge.Domain.Dto.Request;
using Webmotors.Challenge.Domain.Entities;

namespace Webmotors.Challenge.Domain.Interfaces.Repositories
{
    public interface IAnuncioRepository
    {
        IEnumerable<Anuncio> Get();
        Anuncio Get(int id);
        int Add(AnuncioRequest anuncio);
        int Update(int id, AnuncioRequest anuncio);
        Task<int> Delete(int Id);
    }
}
