using BadmintonHub.Dtos.MenuDtos;
using BadmintonHub.Models;
using BadmintonHub.Services;
using BadmintonHub.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BadmintonHub.Controllers
{
    [ApiController]
    [Route("/api/v1/menu")]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService) {
            _menuService = menuService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MenuDto>>> GetAllMenus()
        {
            var results = await _menuService.GetAllMenusAsync();
            return Ok(results.Select(menu => menu.AsDto()));
        }
    }
}
