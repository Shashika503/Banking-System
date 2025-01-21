using Banking_System.Interfaces;
using Banking_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Banking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        /// <summary>
        /// Get the list of product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAccountList()
        {
            var accountDetailsList = await _accountService.GetAllAccounts();
            if (accountDetailsList == null)
            {
                return NotFound();
            }
            return Ok(accountDetailsList);
        }

        [HttpGet("{accountId}")]
        public async Task<IActionResult> GetProductById(int accountId)
        {
            var accountDetails = await _accountService.GetAccountById(accountId);

            if (accountDetails != null)
            {
                return Ok(accountDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="productDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Account accounts)
        {
            var isAccountCreated = await _accountService.CreateAccount(accounts);

            if (isAccountCreated)
            {
                return Ok(isAccountCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Update the product
        /// </summary>
        /// <param name="productDetails"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAccount(Account accounts)
        {
            if (accounts != null)
            {
                var isAccountCreated = await _accountService.UpdateAccount(accounts);
                if (isAccountCreated)
                {
                    return Ok(isAccountCreated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int accountId)
        {
            var isAcountCreated = await _accountService.DeleteAccount(accountId);

            if (isAcountCreated)
            {
                return Ok(isAcountCreated);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}