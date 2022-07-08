using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public async Task<ActionResult> Index()
    {
        return View(_verstaContext.Order.ToList());
    }

    [HttpGet("/order/edit/{id:long}")]
    public async Task<ActionResult> EditOrder(long id)
    {
        var order = await _verstaContext.Order.FirstOrDefaultAsync(prop => prop.IdCargo == id);

        return View(order);
    }

    [HttpPost("/order/edit/{id:long}")]
    public async Task<ActionResult> EditOrder(OrderModel orderModel, long id)
    {
        orderModel.IdCargo = id;
        _verstaContext.Order.Update(orderModel);
        await _verstaContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet("/order/add")]
    public async Task<ActionResult> AddOrder()
    {
        return View();
    }

    [HttpPost("/order/add")]
    public async Task<ActionResult> AddOrder(OrderModel orderModel)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }

        await _verstaContext.Order.AddAsync(orderModel);
        await _verstaContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<ActionResult> DeleteOrder(int id)
    {
        _verstaContext.Order.Remove(new OrderModel
        {
            IdCargo = id
        });

        await _verstaContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }
}