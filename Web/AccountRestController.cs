using bank.Dto;
using bank.Service;
using Microsoft.AspNetCore.Mvc;

namespace bank.Web
{
    [ApiController]
    [Route("accounts")]
    public class AccountRestController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountRestController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("get/{id}")]
        public ActionResult<AccountDTO> GetAccountById(string id)
        {
            var account = _accountService.GetAccountById(id);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpGet("find/{customerId}")]
        public ActionResult<AccountDTO> GetAccountByCustomerId(string customerId)
        {
            var account = _accountService.GetAccountByCustomerId(customerId);
            if (account == null)
            {
                return NotFound();
            }
            return Ok(account);
        }

        [HttpGet("list")]
        public ActionResult<List<AccountDTO>> GetAllAccounts()
        {
            var accounts = _accountService.GetAllAccounts();
            return Ok(accounts);
        }

        [HttpPost("create")]
        public ActionResult<AccountDTO> CreateAccount([FromBody] AccountDTO dto)
        {
            var createdAccount = _accountService.CreateAccount(dto);
            return CreatedAtAction(nameof(GetAccountById), new { id = createdAccount.Id }, createdAccount);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteAccountById(string id)
        {
            var account = _accountService.GetAccountById(id);
            if (account == null)
            {
                return NotFound();
            }
            _accountService.DeleteAccountById(id);
            return NoContent();
        }

        [HttpDelete("clear")]
        public IActionResult DeleteAllAccounts()
        {
            _accountService.DeleteAllAccount();
            return NoContent();
        }
    }
}
