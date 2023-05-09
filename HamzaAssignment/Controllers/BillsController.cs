using HamzaAssignment.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HamzaAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly DataBContext _dataBContext;

        public BillsController(DataBContext dataBContext)
        {
            _dataBContext = dataBContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _dataBContext.bills.ToListAsync();
            return Ok(orders);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBill(int id, [FromBody] Bill_Model updatedBill)
        {
            var bill = await _dataBContext.bills.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }

            bill.Id = updatedBill.Id;
            bill.FirstName = updatedBill.FirstName;
            bill.LastName = updatedBill.LastName;
            bill.City = updatedBill.City;
            bill.PostalCode = updatedBill.PostalCode;
            bill.Email = updatedBill.Email;
            bill.PhoneNumber = updatedBill.PhoneNumber;
            bill.CreditCardNumber = updatedBill.CreditCardNumber;
            bill.CVV = updatedBill.CVV;

            await _dataBContext.SaveChangesAsync();

            return Ok(bill);
        }
    }
}
