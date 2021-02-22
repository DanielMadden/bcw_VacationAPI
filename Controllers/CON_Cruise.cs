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
  public class CruisesController : ControllerBase
  {

    private readonly SER_Cruise _service;

    public CruisesController(SER_Cruise service)
    {
      _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Cruise>> GetAll()
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
    public ActionResult<Cruise> GetById(int id)
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
    public ActionResult<Cruise> Create([FromBody] Cruise newCruise)
    {
      try
      {
        return Ok(_service.Create(newCruise));
      }
      catch (Exception err)
      { return BadRequest(err.Message); }
    }

    [HttpPut("{id}")]
    public ActionResult<Cruise> Edit(int id, [FromBody] JsonElement edits)
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