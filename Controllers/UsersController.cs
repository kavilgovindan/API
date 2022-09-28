using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public UsersController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAppUsers()
        {
            return  await _dataContext.User.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<AppUser>> GetAppUser(int Id)
        {
            return await _dataContext.User.FindAsync(Id);
        }
    }
}