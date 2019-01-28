using System;
using System.Collections.Generic;
using Application.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Webjet.Models;

namespace Webjet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmWorldMovieController : ControllerBase
    {
        private IFilmWorldService _filmWorldService { get; set; }
        private IMapper _mapper { get; set; }

        public FilmWorldMovieController(IFilmWorldService filmWorldService, IMapper mapper)
        {
            _filmWorldService = filmWorldService;
            _mapper = mapper;
        }

        [HttpGet("movies")]
        public ActionResult<ResponseViewModel<List<MoviewViewModel>>> Get()
        {
            try
            {
                var movies = _mapper.Map<List<MoviewViewModel>>(_filmWorldService.Get());

                return new ResponseViewModel<List<MoviewViewModel>>
                {
                    Success = true,
                    Data = movies,
                    Message = ""
                };
            }
            catch (Exception e)
            {
                return new ResponseViewModel<List<MoviewViewModel>>
                {
                    Success = false,
                    Data = null,
                    Message = e.Message
                };
            }
        }

        [HttpGet("movies/{id}")]
        public ActionResult<ResponseViewModel<MoviewViewModel>> Get(Guid id)
        {
            try
            {
                var movie = _mapper.Map<MoviewViewModel>(_filmWorldService.Get(id));

                return new ResponseViewModel<MoviewViewModel>
                {
                    Success = true,
                    Data = movie,
                    Message = ""
                };
            }
            catch (Exception e)
            {
                return new ResponseViewModel<MoviewViewModel>
                {
                    Success = false,
                    Data = null,
                    Message = e.Message
                };
            }
        }
    }
}
