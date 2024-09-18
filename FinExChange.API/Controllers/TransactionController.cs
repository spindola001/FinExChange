using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinExChange.API.Data;
using FinExChange.API.Models;

namespace FinExChange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly FinExChangeAPIContext _context;

        public TransactionController(FinExChangeAPIContext context)
        {
            _context = context;
        }

        // GET: api/Transaction
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionModel>>> GetTransactionModel()
        {
            return await _context.TransactionModel.ToListAsync();
        }

        // GET: api/Transaction/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionModel>> GetTransactionModel(int id)
        {
            var transactionModel = await _context.TransactionModel.FindAsync(id);

            if (transactionModel == null)
            {
                return NotFound();
            }

            return transactionModel;
        }

        // PUT: api/Transaction/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionModel(int id, TransactionModel transactionModel)
        {
            if (id != transactionModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(transactionModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionModelExists(id))
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

        // POST: api/Transaction
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransactionModel>> PostTransactionModel(TransactionModel transactionModel)
        {
            _context.TransactionModel.Add(transactionModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransactionModel", new { id = transactionModel.Id }, transactionModel);
        }

        // DELETE: api/Transaction/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionModel(int id)
        {
            var transactionModel = await _context.TransactionModel.FindAsync(id);
            if (transactionModel == null)
            {
                return NotFound();
            }

            _context.TransactionModel.Remove(transactionModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransactionModelExists(int id)
        {
            return _context.TransactionModel.Any(e => e.Id == id);
        }
    }
}
