using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Webmotors.Challenge.Domain.Dto.Request;
using Webmotors.Challenge.Domain.Entities;
using Webmotors.Challenge.Domain.Interfaces.Repositories;
using Webmotors.Challenge.Domain.Interfaces.Services;

namespace Webmotors.Challenge.Service
{
    public class AnuncioService : IAnuncioService
    {
        private readonly IAnuncioRepository _anuncioRepository;
        public AnuncioService(IAnuncioRepository anuncioRepository)
        {
            _anuncioRepository = anuncioRepository;
        }

        public IEnumerable<Anuncio> Get()
        {
            IEnumerable<Anuncio> list = _anuncioRepository.Get();
            return list;
        }
        public Anuncio Get(int id)
        {
            return _anuncioRepository.Get(id);
        }
        public void Add(AnuncioRequest anuncio)
        {
            _anuncioRepository.Add(anuncio);
        }
        public void Update(int id, AnuncioRequest anuncio)
        {
            _anuncioRepository.Update(id, anuncio);
        }
        public void Delete(int id)
        {
            _anuncioRepository.Delete(id);
        }
    }
}
