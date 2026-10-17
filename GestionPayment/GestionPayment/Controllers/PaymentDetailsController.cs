using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionPayment.Models;

[Route("api/[controller]")]
[ApiController]
public class PaymentDetailsController : ControllerBase
{
    private readonly PaymentDetailContext _context;
    public PaymentDetailsController(PaymentDetailContext context)
    {
        _context = context;
    }

    // GET: api/PaymentDetails
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PaymentDetails>>> GetPaymentDetails()
    {
        return await _context.PaymentDetails.ToListAsync();
    }

    // GET: api/PaymentDetails/5
    [HttpGet("{paymentdetailsid}")]
    public async Task<ActionResult<PaymentDetails>> GetPaymentDetails(int paymentdetailsid)
    {
        var paymentdetails = await _context.PaymentDetails.FindAsync(paymentdetailsid);

        if (paymentdetails == null)
        {
            return NotFound();
        }

        return paymentdetails;
    }

    // PUT: api/PaymentDetails/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{paymentdetailsid}")]
    public async Task<IActionResult> PutPaymentDetails(int? paymentdetailsid, PaymentDetails paymentdetails)
    {
        if (paymentdetailsid != paymentdetails.PaymentDetailsId)
        {
            return BadRequest();
        }

        _context.Entry(paymentdetails).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PaymentDetailsExists(paymentdetailsid))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/PaymentDetails
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<PaymentDetails>> PostPaymentDetails(PaymentDetails paymentdetails)
    {
        _context.PaymentDetails.Add(paymentdetails);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPaymentDetails", new { paymentdetailsid = paymentdetails.PaymentDetailsId }, paymentdetails);
    }

    // DELETE: api/PaymentDetails/5
    [HttpDelete("{paymentdetailsid}")]
    public async Task<IActionResult> DeletePaymentDetails(int? paymentdetailsid)
    {
        var paymentdetails = await _context.PaymentDetails.FindAsync(paymentdetailsid);
        if (paymentdetails == null)
        {
            return NotFound();
        }

        _context.PaymentDetails.Remove(paymentdetails);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PaymentDetailsExists(int? paymentdetailsid)
    {
        return _context.PaymentDetails.Any(e => e.PaymentDetailsId == paymentdetailsid);
    }
}
