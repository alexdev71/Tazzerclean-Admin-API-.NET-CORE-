using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using DataContracts.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceContracts.Admin;

namespace TazzerClean.Api.Controllers
{
    [Route("api/admin")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IAdminManager _adminManager;
        public AdminController(ILogger<AdminController> logger, IAdminManager adminManager)
        {
            _logger = logger;
            _adminManager = adminManager;
        }
        #region zipcodes
        [HttpPost]
        [Route("zipcodesall")]
        public async Task<ActionResult<List<PostalLookup>>> ZipCodesGetAll()
        {
            try
            {
                var zipCodes = await _adminManager.GetAllZipCodes();
                return zipCodes;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in ZipCodesGetAll");
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("deleteZipCode")]
        public async Task<ActionResult<List<PostalLookup>>> DeleteZipCode(Guid id)
        {
            try
            {
                await _adminManager.DeleteZipCode(id);

                var zipCodes = await _adminManager.GetAllZipCodes();
                return zipCodes;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in ZipCodesGetAll");
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("addOrUpdateZipCode")]
        public async Task<ActionResult<List<PostalLookup>>> AddOrUpdate(PostalLookup lookup)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(lookup.Id.ToString()))
                {
                    lookup.Id = Guid.NewGuid();
                }

                await _adminManager.AddOrUpdateZipCode(lookup);

                var zipCodes = await _adminManager.GetAllZipCodes();
                return zipCodes;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in ZipCodesGetAll");
                return BadRequest(ex);
            }
        }
        #endregion

        #region category type
        [HttpPost]
        [Route("typegetall")]
        public async Task<ActionResult<List<CategoryType>>> CategoryTypeGetAll()
        {
            try
            {
                var types = await _adminManager.GetAllCategoryType();
                return types;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in CategoryTypeGetAll");
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("deleteCategoryType")]
        public async Task<ActionResult<List<CategoryType>>> DeleteCategoryType(Guid id)
        {
            try
            {
                await _adminManager.DeleteCategoryType(id);

                var types = await _adminManager.GetAllCategoryType();
                return types;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in ZipCodesGetAll");
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("addOrUpdateCategoryType")]
        public async Task<ActionResult<List<CategoryType>>> AddOrUpdateCategoryType(CategoryType type)
        {
            try
            {
                if (type.Id == Guid.Empty)
                {
                    type.Id = Guid.NewGuid();
                }

                await _adminManager.AddOrUpdateCategoryType(type);

                var types = await _adminManager.GetAllCategoryType();
                return types;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in ZipCodesGetAll");
                return BadRequest(ex);
            }
        }
        #endregion

        [HttpPost]
        [Route("subtypegetall")]
        public async Task<ActionResult<List<CategoryType>>> CategorySubTypeGetAll()
        {
            try
            {
                var types = await _adminManager.GetAllCategorySubType();
                return types;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in CategoryTypeGetAll");
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("subtypegetbytypeid")]
        public async Task<ActionResult<List<CategoryType>>> CategoryGetByTypeId(Guid id)
        {
            try
            {
                var types = await _adminManager.GetByTypeId(id);
                return types;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in CategoryTypeGetAll");
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("deleteCategorySubType")]
        public async Task<ActionResult<List<CategoryType>>> DeleteCategorySubType(Guid id)
        {
            try
            {
                await _adminManager.DeleteCategorySubType(id);

                var types = await _adminManager.GetAllCategorySubType();
                return types;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in ZipCodesGetAll");
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("addOrUpdateCategorySubType")]
        public async Task<ActionResult<List<CategoryType>>> AddOrUpdateCategorySubType(CategoryType type)
        {
            try
            {
                if (type.Id == Guid.Empty)
                {
                    type.Id = Guid.NewGuid();
                }

                await _adminManager.AddOrUpdateCategorySubType(type);

                var types = await _adminManager.GetAllCategorySubType();
                return types;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in ZipCodesGetAll");
                return BadRequest(ex);
            }
        }


        #region category
        [HttpPost]
        [Route("categoryGetAll")]
        public async Task<ActionResult<List<Category>>> CategoryGetAll()
        {
            try
            {
                var cat = await _adminManager.GetAllCategories();
                return cat;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in CategoryGetAll");
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("deleteCategory")]
        public async Task<ActionResult<List<Category>>> DeleteCategory(Guid id)
        {
            try
            {
                await _adminManager.DeleteCategory(id);

                var cat = await _adminManager.GetAllCategories();
                return cat;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in DeleteCategory");
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("addOrUpdateCategory")]
        public async Task<ActionResult<List<Category>>> AddOrUpdateCategory(Category type)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(type.Id.ToString()) || type.Id == Guid.Empty)
                {
                    type.Id = Guid.NewGuid();
                }

                await _adminManager.AddOrUpdateCategory(type);

                var cat = await _adminManager.GetAllCategories();
                return cat;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in ZipCodesGetAll");
                return BadRequest(ex);
            }
        }
        #endregion

        [HttpPost]
        [Route("customersGetAll")]
        public async Task<ActionResult<List<Customer>>> CustomersGetAll()
        {
            try
            {
                var cat = await _adminManager.GetAllCustomers();
                return cat;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in CustomersGetAll");
                return BadRequest(ex);
            }
        }


        [HttpDelete]
        [Route("deleteCustomer")]
        public async Task<ActionResult<List<Customer>>> DeleteCustomer(Guid id)
        {
            try
            {
                await _adminManager.DeleteCustomer(id);

                var proff = await _adminManager.GetAllCustomers();
                return proff;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in ZipCodesGetAll");
                return BadRequest(ex);
            }
        }


        [HttpGet]
        [Route("activeCustomer")]
        public async Task<ActionResult<List<Customer>>> ActiveCustomer(Guid id)
        {
            try
            {
                await _adminManager.ActiveCustomer(id);

                var proff = await _adminManager.GetAllCustomers();
                return proff;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in ZipCodesGetAll");
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("deactiveCustomer")]
        public async Task<ActionResult<List<Customer>>> DeactiveCustomer(Guid id)
        {
            try
            {
                await _adminManager.DeactiveCustomer(id);

                var proff = await _adminManager.GetAllCustomers();
                return proff;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in ZipCodesGetAll");
                return BadRequest(ex);
            }
        }


        [HttpPost]
        [Route("professionals")]
        public async Task<ActionResult<List<Professional>>> ProfessionalsGetAll()
        {
            try
            {
                var proff = await _adminManager.GetAllProfessionals();
                return proff;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in ProfessionalsGetAll");
                return BadRequest(ex);
            }
        }


        [HttpDelete]
        [Route("deleteProfessional")]
        public async Task<ActionResult<List<Professional>>> DeleteProfessional(Guid id)
        {
            try
            {
                await _adminManager.DeleteProfessional(id);

                var proff = await _adminManager.GetAllProfessionals();
                return proff;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in ZipCodesGetAll");
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("activeProfessional")]
        public async Task<ActionResult<List<Professional>>> ActiveProfessional(Guid id)
        {
            try
            {
                await _adminManager.ActiveProfessional(id);

                var proff = await _adminManager.GetAllProfessionals();
                return proff;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in ZipCodesGetAll");
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("deactiveProfessional")]
        public async Task<ActionResult<List<Professional>>> DeactiveProfessional(Guid id)
        {
            try
            {
                await _adminManager.DeactiveProfessional(id);

                var proff = await _adminManager.GetAllProfessionals();
                return proff;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in ZipCodesGetAll");
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("partners")]
        public async Task<ActionResult<List<Partner>>> PartnersGetAll()
        {
            try
            {
                var partners = await _adminManager.GetAllPartners();
                return partners;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in PartnersGetAll");
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        [Route("deletePartner")]
        public async Task<ActionResult<List<Partner>>> DeletePartner(Guid id)
        {
            try
            {
                await _adminManager.DeletePartner(id);

                var proff = await _adminManager.GetAllPartners();
                return proff;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in ZipCodesGetAll");
                return BadRequest(ex);
            }
        }


        [HttpGet]
        [Route("activePartner")]
        public async Task<ActionResult<List<Partner>>> ActivePartner(Guid id)
        {
            try
            {
                await _adminManager.ActivePartner(id);

                var proff = await _adminManager.GetAllPartners();
                return proff;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in ZipCodesGetAll");
                return BadRequest(ex);
            }
        }


        [HttpGet]
        [Route("deactivePartner")]
        public async Task<ActionResult<List<Partner>>> DeactivePartner(Guid id)
        {
            try
            {
                await _adminManager.DeactivePartner(id);

                var proff = await _adminManager.GetAllPartners();
                return proff;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in ZipCodesGetAll");
                return BadRequest(ex);
            }
        }

    }
}
