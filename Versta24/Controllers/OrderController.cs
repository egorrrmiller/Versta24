using Microsoft.AspNetCore.Mvc;
using Versta24.DataBase;
using Versta24.Models;

namespace Versta24.Controllers;

public class OrderController : Controller
{
    private readonly VerstaContext _verstaContext;

    public OrderController(VerstaContext verstaContext)
    {
        _verstaContext = verstaContext;
    }

    [HttpGet]
    public ActionResult Index()
        => View(_verstaContext.Order.ToList());
    
    [HttpGet]
    public ActionResult AddOrder() 
        => View();

    [HttpPost]
    public ActionResult AddOrder(OrderModel orderModel)
    {
        if (!ModelState.IsValid) return View();

        _verstaContext.Order.Add(orderModel);
        _verstaContext.SaveChanges();
        
        return RedirectToAction(nameof(Index));
    }
    
    public ActionResult DeleteOrder(int id)
    {
        _verstaContext.Order.Remove(new OrderModel { IdCargo = id });
        _verstaContext.SaveChanges();
        
        return RedirectToAction(nameof(Index));
    }
}