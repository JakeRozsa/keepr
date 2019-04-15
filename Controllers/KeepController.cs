using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    private readonly KeepRepository _kr;
    public KeepsController(KeepRepository kr)
    {
      _kr = kr;
    }
    //CREATE
    [HttpPost]
    public ActionResult<Keep> Create([FromBody] Keep keepy)
    {
      Keep newKeepy = _kr.CreateKeep(keepy);
      if (newKeepy == null)
      {
        return BadRequest("Can't create that Keep!");
      }
      return Ok(newKeepy);
    }
    //GETALL
    [HttpGet]
    public ActionResult<IEnumerable<KeepsController>> Get()
    {
      IEnumerable<Keep> results = _kr.GetALL();
      if (results == null)
      {
        return BadRequest();
      }
      return Ok(results);
    }
    //GETBYID
    [HttpGet("{id}")]
    public ActionResult<Keep> GetById(int id)
    {
      Keep found = _kr.GetById(id);
      if (found == null)
      {
        return BadRequest();
      }
      return Ok(found);
    }
    //GET KEEPS BY VAULT ID
    [HttpGet("{id}/vaults")]
    public ActionResult<IEnumerable<Keep>> GetKeeps(int id)
    {
      return Ok(_kr.GetKeeps(id));
    }
    //DELETE
    [HttpDelete]
    public ActionResult<string> Delete(int id)
    {
      bool successful = _kr.Delete(id);
      if (!successful)
      {
        return BadRequest();
      }
      return Ok();
    }
  }
}