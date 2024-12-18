using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VetClinic.BL.Reviews.Entities;
using VetClinic.BL.Reviews;
using VetClinic.WebAPI.Controllers.Entities;

namespace VetClinic.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReviewController : Controller
    {
        private readonly IReviewsProvider _reviewsProvider;
        private readonly IReviewsManager _reviewsManager;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ReviewController(IReviewsProvider reviewsProvider, IReviewsManager reviewsManager, IMapper mapper, ILogger logger)
        {
            _reviewsManager = reviewsManager;
            _reviewsProvider = reviewsProvider;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet] //reviews/
        public IActionResult GetAllReviews()
        {
            var reviews = _reviewsProvider.GetReviews();
            return Ok(new ReviewsListResponce()
            {
                Reviews = reviews.ToList()
            });
        }

        [HttpGet]
        [Route("filter")] //reviews/filter?filter.Price = 500&filter.Status = 1&filter.PublishingHouseId = 1&filter.LanguageId = 1&filter.ReviewType = 1 
        public IActionResult GetFilteredReviews([FromQuery] ReviewsFilter filter)
        {
            var reviews = _reviewsProvider.GetReviews(_mapper.Map<ReviewModelFilter>(filter));
            return Ok(new ReviewsListResponce()
            {
                Reviews = reviews.ToList()
            });
        }

        [HttpGet]
        [Route("{id}")] //reviews/{id}
        public IActionResult GetReviewInfo([FromRoute] Guid id)
        {
            try
            {
                var review = _reviewsProvider.GetReviewInfo(id);
                return Ok(review);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateReview([FromBody] CreateReviewRequest request)
        {
            try
            {
                var review = _reviewsManager.CreateReview(_mapper.Map<CreateReviewModel>(request));
                return Ok(review);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateReviewInfo([FromRoute] Guid id, UpdateReviewRequest request)
        {
            try
            {
                var review = _reviewsManager.UpdateReview(id, _mapper.Map<UpdateReviewModel>(request));
                return Ok(review);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteReview([FromRoute] Guid id)
        {
            try
            {
                _reviewsManager.DeleteReview(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);

            }
        }
    }

}
