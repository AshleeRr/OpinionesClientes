using Microsoft.AspNetCore.Mvc;
using OpinionesClientes.API.Data.Interfaces;

namespace OpinionesClientes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : Controller
    {
        private readonly ICommentsRepository _commentsRepository;
        public CommentsController(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }
        [HttpGet("GetAllComments")]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _commentsRepository.GetAllCommentsAsync();
            return Ok(comments);
        }
    }
}
