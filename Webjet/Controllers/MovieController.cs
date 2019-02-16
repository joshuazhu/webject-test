using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application;
using Application.Interface;
using Application.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Webjet.Models;

namespace Webjet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovieService _movieService { get; set; }
        private IMapper _mapper { get; set; }

        public MovieController(IMovieService movieService, IMapper mapper)
        {
            _movieService = movieService;
            _mapper = mapper;
        }

        [HttpGet("movies")]
        public async Task<ActionResult<ResponseViewModel<MovieGroupsByTitle>>> Get()
        {
            try
            {
                var movies = await _movieService.GetAllMovies();

                return new ResponseViewModel<MovieGroupsByTitle>
                {
                    Success = true,
                    Data = movies,
                    Message = ""
                };
            }
            catch (Exception e)
            {
                return new ResponseViewModel<MovieGroupsByTitle>
                {
                    Success = false,
                    Data = null,
                    Message = e.Message
                };
            }
        }

        [HttpGet("movies/{source}/{id}")]
        public async Task<ActionResult<ResponseViewModel<MovieDetail>>> Get(int source, string id)
        {
            try
            {
                var movie = await _movieService.GetMovieDetail(source, id);

                return new ResponseViewModel<MovieDetail>
                {
                    Success = true,
                    Data = movie,
                    Message = ""
                };
            }
            catch (Exception e)
            {
                return new ResponseViewModel<MovieDetail>
                {
                    Success = false,
                    Data = null,
                    Message = e.Message
                };
            }
        }
    }
}
