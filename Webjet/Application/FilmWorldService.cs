using System;
using System.Collections.Generic;
using Application.Exception;
using Application.Interface;
using Domain.Entity;
using Repository.Interface;

namespace Application
{
    public class FilmWorldService : IFilmWorldService
    {
        private IFilmWorldRepository _filmWorldRepository { get; set; }

        public FilmWorldService(IFilmWorldRepository fileFilmWorldRepository)
        {
            _filmWorldRepository = fileFilmWorldRepository;
        }

        public IEnumerable<Movie> Get()
        {
            GenerateServiceNotAvailable();
            return _filmWorldRepository.Get();
        }

        public Movie Get(Guid id)
        {
            GenerateServiceNotAvailable();
            return _filmWorldRepository.Get(id);
        }

        /// <summary>
        /// Throw service not available exception in 1/4 chance
        /// </summary>
        private void GenerateServiceNotAvailable()
        {
            var random = new Random();
            var randomNumber = random.Next(1, 5);

            if (randomNumber == 4)
                throw new ServiceNotAvailableException("Film World is currently not available");

        }
    }
}
