using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using DataAccess.Database.Interfaces;
using DataContracts.Entities;
using ImageMagick;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceContracts.UserManager;

namespace TazzerClean.Api.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserManager _userManager;
        private readonly IAzureRepository _azureRepository;


        public UserController(ILogger<UserController> logger,IUserManager userManager,IAzureRepository azureRepository)
        {
            _logger = logger;
            _userManager = userManager;
            _azureRepository = azureRepository;
        }

        [HttpGet]
        [Route("getbyusername")]
        public async Task<ActionResult<User>> GetUserByUsername()
        {
            try
            {

                var user = User.Claims?.FirstOrDefault(x => x.Type.Equals("UserName", StringComparison.OrdinalIgnoreCase))?.Value;

                var result = await _userManager.FindByName(user);



                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in AuthController:Login");
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("updateProfileImage")]
        public async Task<ActionResult<User>> UpdateUserProfileImage()
        {
            try
            {
                var fileType = Request.ContentType;

                if (!fileType.Contains("multipart/form-data"))
                {
                    return BadRequest();
                }

                var username = User.Claims?.FirstOrDefault(x => x.Type.Equals("UserName", StringComparison.OrdinalIgnoreCase))?.Value;


                var file = Request.Form.Files[0];

                if(file != null)
                {
                    MemoryStream ms = new MemoryStream();
                    await file.CopyToAsync(ms);
                    var fileContent = ms.ToArray();
                    var fileId = Guid.NewGuid();
                    var loweredFileName = file.FileName.ToLowerInvariant();
                    var resizedImage = new byte[] { };
                    if(loweredFileName.EndsWith(".jpg") || loweredFileName.EndsWith(".png") || loweredFileName.EndsWith(".PNG"))
                    {
                        using(var image = new MagickImage(fileContent))
                        {
                            image.Quality = 100;
                            resizedImage = image.ToByteArray();
                        }

                        var url = await _azureRepository.StoreFile(loweredFileName, fileId, resizedImage);

                        await _userManager.UpdateUserProfileImage(url,username);


                    }
                }

                var result = await _userManager.FindByName(username);


                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in AuthController:Login");
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("updateProfile")]
        public async Task<ActionResult<User>> UpdateUser(User user)
        {
            try 
            {
                var username = User.Claims?.FirstOrDefault(x => x.Type.Equals("UserName", StringComparison.OrdinalIgnoreCase))?.Value;

                await _userManager.UpdateProfile(user);

                var result = await _userManager.FindByName(username);

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has been thrown in UserController:UpdateUser");
                return BadRequest(ex);
            }
        }

    }
}
