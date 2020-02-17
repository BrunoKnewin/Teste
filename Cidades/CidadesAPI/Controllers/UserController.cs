using Cidades.Application.Interfaces;
using Cidades.Application.ViewModels.Common;
using Cidades.Application.ViewModels.Request;
using Cidades.Application.ViewModels.Response;
using Cidades.Domain.Containers;
using CidadesAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CidadesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody]LoginRequestViewModel model)
        {
            try
            {
                var result = _userAppService.Authenticate(model);
                if (!result.IsValid())
                {
                    return Ok(new RequestResult<LoginResponseViewModel>(500, result.Messages));
                }
                result = TokenService.GenerateToken(result);

                return Ok(result);
            }
            catch (Exception)
            {
                return Ok(new RequestResult<LoginResponseViewModel>(500, new List<string>() { "Ocorreu um erro ao authenticar o usuário" }));
            }
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar([FromBody] AddUserRequestViewModel model)
        {
            try
            {
                var result = _userAppService.Cadastrar(model);

                if (!result.IsValid())
                {
                    return Ok(new RequestResult<BaseResponseViewModel>(500, new List<string>() { result.Messages[0] }));
                }

                return Ok("Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                return Ok(new RequestResult<BaseResponseViewModel>(500, new List<string>() { "Ocorreu um erro ao cadastrar o usuário" }));
            }
        }
    }
}