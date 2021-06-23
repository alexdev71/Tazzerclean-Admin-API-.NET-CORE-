using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataContracts.Entities;
using DataContracts.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceContracts.CategoryManager;

namespace TazzerClean.Api.Controllers
{
    [Route("api/category")]
    [ApiController]
    [AllowAnonymous]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryManager _categoryManager;
        public CategoryController(ILogger<CategoryController> logger, ICategoryManager categoryManager)
        {
            _logger = logger;
            _categoryManager = categoryManager;
        }

        [HttpPost]
        [Route("all")]
        public async Task<ActionResult<List<Category>>> GetAll()
        {
            try
            {
                var categories = await _categoryManager.GetAll();
                return categories;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in CategoryController:GetAll");
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("getAllCategoriesForMenu")]
        public async Task<ActionResult<List<CategoryNavigationVM>>> GetAllForMenu()
        {
            try
            {
                var categories = await _categoryManager.GetAllForMenu();
                return categories;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in CategoryController:GetAll");
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("find")]
        public async Task<ActionResult<List<CategoryTypeVM>>> FindByName(string name)
        {
            try
            {
                var result = await _categoryManager.FindByName(name);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in CategoryController:FindByName");
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("add")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<Category>> AddCategory([FromBody] Category request)
        {
            try
            {
                var categoryType = new Category
                {

                };

                var result = await _categoryManager.AddCategory(categoryType);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in CategoryController:AddCategory");
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("getById")]
        public async Task<ActionResult<List<Category>>> GetById(string id)
        {
            try
            {
                var guidId = Guid.Parse(id);
                var result = await _categoryManager.GetTypeById(guidId);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in CategoryController:GetTypeById");
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("deleteCategoryType")]
        [AllowAnonymous]
        public async Task<ActionResult<Category>> DeleteCategoryType(string id)
        {
            try
            {
                var result = await _categoryManager.DeleteCategoryType(id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in CategoryController:DeleteCategoryType");
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("getByName")]
        public async Task<ActionResult<List<Category>>> GetByName(string name)
        {
            try
            {
                var result = await _categoryManager.GetByName(name);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in CategoryController:GetTypeById");
                return BadRequest(ex);
            }
        }
    }
}
