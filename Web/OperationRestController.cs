using bank.Dto;
using bank.Enums;
using bank.Service;
using Microsoft.AspNetCore.Mvc;

namespace bank.Web
{

    [ApiController]
    [Route("operations")]
    public class OperationRestController : ControllerBase
    {
        private readonly IOperationService _operationService;

        public OperationRestController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        [HttpPost("transaction")]
        public ActionResult<OperationResponseDTO> Transaction([FromBody] OperationRequestDTO dto)
        {
            if (dto.Type == OperationType.CREDIT)
            {
                return Ok(_operationService.Credit(dto.AccountId, dto.Amount, dto.Description));
            }
            else if (dto.Type == OperationType.DEBIT)
            {
                return Ok(_operationService.Debit(dto.AccountId, dto.Amount, dto.Description));
            }
            else
            {
                return BadRequest("Operation's type must be CREDIT or DEBIT");
            }
        }

        [HttpGet("all")]
        public ActionResult<List<OperationResponseDTO>> GetAllOperations()
        {
            var operations = _operationService.GetAllOperations();
            return Ok(operations);
        }

        [HttpGet("list/{accountId}")]
        public ActionResult<List<OperationResponseDTO>> GetAllOperationsByAccountId(string accountId)
        {
            var operations = _operationService.GetAllOperationsByAccountId(accountId);
            return Ok(operations);
        }

        [HttpGet("get/{id}")]
        public ActionResult<OperationResponseDTO> GetOperationById(string id)
        {
            var operation = _operationService.GetOperationById(id);
            if (operation == null)
            {
                return NotFound();
            }
            return Ok(operation);
        }
    }
}
