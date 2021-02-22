using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Vacation.Models;
using Vacation.Services;

namespace Vacation.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TripsController : ControllerBase
  {

    private readonly SER_Trip _service;

    public TripsController(SER_Trip service)
    {
      _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Trip>> GetAll()
    {
      try
      {
        return Ok(_service.GetAll());
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Trip> GetById(int id)
    {
      try
      {
        return Ok(_service.GetById(id));
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public ActionResult<Trip> Create([FromBody] Trip newTrip)
    {
      try
      {
        return Ok(_service.Create(newTrip));
      }
      catch (Exception err)
      { return BadRequest(err.Message); }
    }

    [HttpPut("{id}")]
    public ActionResult<Trip> Edit(int id, [FromBody] JsonElement edits)
    {
      try
      {
        return Ok(_service.Edit(id, edits));
      }
      catch (Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_service.Delete(id) + " rows deleted");
      }
      catch (Exception err)
      { return BadRequest(err.Message); }
    }
  }
}