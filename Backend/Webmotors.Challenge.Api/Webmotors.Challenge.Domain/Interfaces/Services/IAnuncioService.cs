using System.Collections.Generic;
using Webmotors.Challenge.Domain.Dto.Request;
using Webmotors.Challenge.Domain.Entities;

namespace Webmotors.Challenge.Domain.Interfaces.Services
{
    public interface IAnuncioService
    {
        IEnumerable<Anuncio> Get();
        Anuncio Get(int id);
        void Add(AnuncioRequest anuncio);
        void Update(int id, AnuncioRequest anuncio);
        void Delete(int id);
    }
}
