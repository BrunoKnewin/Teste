using AutoMapper;
using Knewin.CityApi.ViewModels.Account;
using Knewin.Domain.Entities;
using Knewin.Infra.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Knewin.Core.Extensions;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Knewin.CityApi.Controllers
{
    [ApiController]
    [Route("api/[controller]"), ApiVersion("1")]
    public class AccountController : Controller
    {


        private readonly IMapper _mapper;

        private readonly IAccountCrudService _accountService;

        public AccountController(IMapper mapper, IAccountCrudService accountService)
        {
            _accountService = accountService;
        }

        // POST api/account
        [HttpPost]
        public ActionResult Post([FromBody]AccountViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var account = new Account()
                {
                    Email = viewModel.Email,
                    Password = viewModel.Password.HashPassword(),
                };

                _accountService.Insert(account);
            } catch(Exception ex) { }

            return Ok();
        }

        // POST api/account/authenticate
        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate([FromBody] AccountViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var account = _accountService.Authenticate(viewModel.Email, viewModel.Password);

            if (account == null)
                return Unauthorized();

            return Ok(account.Token);
        }
    }
}