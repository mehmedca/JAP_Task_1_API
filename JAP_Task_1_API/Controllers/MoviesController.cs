using JAP.Core.Models.InsertRequest;
using JAP.Core.Models.UpdateRequest;
using JAP.Core.Models.SearchRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JAP.Core.Interfaces.IService;
using JAP.Core.Models;
using JAP.Core.Entities;
using Microsoft.AspNetCore.Authorization;

namespace JAP_Task_1_API.Controllers
{
    [Authorize]
    public class MoviesController : BaseApiController
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _movieService.GetMovieByIdAsync(id));
        }

        [Authorize(Policy = "RequireModeratorRole")]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] MovieInsertRequest insertRequest)
        {
            return Ok(await _movieService.InsertMovieAsync(insertRequest));
        }

        [Authorize(Policy = "RequireModeratorRole")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, [FromBody] MovieUpdateRequest updateRequest)
        {
            await _movieService.UpdateMovieAsync(id, updateRequest);
            return NoContent();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetPage([FromQuery] MovieSearchRequest search)
        {
            return Ok(await _movieService.GetPageAsync(search));
        }

        [Authorize(Policy = "RequireAdminRole")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _movieService.SoftDeleteMovieAsync(id);
            return Ok(true);
        }



        //RATINGS

        //Get movie ratings
        [HttpGet("get-ratings/{id}")]
        public async Task<IActionResult> GetMovieRatings(int id)
        {
            return Ok(await _movieService.GetMovieRatingsAsync(id));
        }

        //Add new rating
        [HttpPost("add-rating")]
        public async Task<IActionResult> AddMovieRating(RatingInsertRequest request)
        {
            await _movieService.AddMovieRatingAsync(request);
            return Ok();
        }


        // MOVIE PHOTO
        [Authorize(Policy = "RequireModeratorRole")]
        [HttpPost("add-photo")]
        public async Task<ActionResult<PhotoModel>> AddPhoto(PhotoInsertRequest request)
        {
            //Insert request will contain IFormFile (photo) and Id which will act as MovieId or ActorId depending on the situation
            var photoModel = await _movieService.AddMovieCoverPhotoAsync(request);
            if (photoModel == null) return BadRequest("Problem addding photo");

            return Ok(photoModel);
        }
    }
}
