using Banking_System.Interfaces;
using Banking_System.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Banking_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        public readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService tranasctionService)
        {
            _transactionService = tranasctionService;
        }

        /// <summary>
        /// Get the list of product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTrasactionList()
        {
            var transDetailsList = await _transactionService.GetAllTrasactions();
            if (transDetailsList == null)
            {
                return NotFound();
            }
            return Ok(transDetailsList);
        }

        [HttpGet("{transactionId}")]
        public async Task<IActionResult> GetProductById(int transactionId)
        {
            var transDetails = await _transactionService.GetTransctionById(transactionId);

            if (transDetails != null)
            {
                return Ok(transDetails);
            }
            else
            {
                return BadRequest();
            }
        }

   
        [HttpPost]
        public async Task<IActionResult> CreateTransaction(Transaction trasactions)
        {
            var isTransactionCreated = await _transactionService.CreateTranasction(trasactions);

            if (isTransactionCreated)
            {
                return Ok(isTransactionCreated);
            }
            else
            {
                return BadRequest();
            }
        }

       
        [HttpPut]
        public async Task<IActionResult> UpdateTransaction(Transaction transactions)
        {
            if (transactions != null)
            {
                var isTransCreated = await _transactionService.UpdateTransaction(transactions);
                if (isTransCreated)
                {
                    return Ok(isTransCreated);
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
        [HttpDelete("{transactionId}")]
        public async Task<IActionResult> DeleteProduct(int transactionId)
        {
            var isTransCreated = await _transactionService.DeleteTransaction(transactionId);

            if (isTransCreated)
            {
                return Ok(isTransCreated);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}