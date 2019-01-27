using System;
using System.Collections.Generic;
using Application.Exception;
using Application.Interface;
using Domain.Entity;
using Repository.Interface;

namespace Application
{
    public class CinemaWorldService : ICinemaWorldService
    {
        private ICinemaWorldRepository _cinemaWorldRepository { get; set; }

        public CinemaWorldService(ICinemaWorldRepository cinemaWorldRepository)
        {
            _cinemaWorldRepository = cinemaWorldRepository;
        }

        public IEnumerable<Movie> Get()
        {
            GenerateServiceNotAvailable();
            return _cinemaWorldRepository.Get();
        }

        public Movie Get(Guid id)
        {
            GenerateServiceNotAvailable();
            return _cinemaWorldRepository.Get(id);
        }

        /// <summary>
        /// Throw service not available exception in 1/3 chance
        /// </summary>
        private void GenerateServiceNotAvailable()
        {
            var random = new Random();
            var randomNumber = random.Next(1, 4);

            if (randomNumber == 3)
                throw new ServiceNotAvailableException("Cinema World is currently not available");

        }
    }
}
