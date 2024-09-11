using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Parking_Management_System.Models;
using System.Net;

namespace Parking_Management_System.Controllers
{
    public class ParkingTransactionsController : Controller
    {
        public readonly ApplicationDbContext _DbContext;
        public ParkingTransactionsController(ApplicationDbContext dbContext) {
            _DbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var allTransactionDetails = _DbContext.ParkingTransactions.ToList();
            return View(allTransactionDetails);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ParkingTransaction parkingTransaction)
        {
            if (ModelState.IsValid) 
            {
                _DbContext.ParkingTransactions.Add(parkingTransaction);
                await _DbContext.SaveChangesAsync();
            }
               return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public ActionResult Update(int? Id)
        {
            if(Id == null)
            {
                return NotFound();
            }

            var transaction = _DbContext.ParkingTransactions.FirstOrDefault(x => x.Id == Id);

            if (transaction == null) { 
            return NotFound();
            }
             return View(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? Id, ParkingTransaction parkingTransaction)
        {
            if (Id == parkingTransaction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _DbContext.ParkingTransactions.Update(parkingTransaction);
                await _DbContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public ActionResult Delete(int? Id)
        {
            var transaction = _DbContext.ParkingTransactions.FirstOrDefault();

            if (transaction == null)
            {
                return NotFound();
            }

            return View(transaction);

        }

        [HttpDelete]
        public ActionResult Delete() 
        {
            var transaction = _DbContext.ParkingTransactions.FirstOrDefault();

            if (transaction == null) {
                return NotFound();
            }

            _DbContext.ParkingTransactions.Remove(transaction);
            _DbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        }
    }
