using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
    public ActionResult<IEnumerable<Keep>> Get()
    {
      IEnumerable<Keep> results = _kr.GetALL();
      if (results == null)
      {
        return BadRequest();
      }
      return Ok(results);
    }
    //GETBYUSERID
    [Authorize]
    [HttpGet("user/profile")]
    public ActionResult<IEnumerable<Keep>> GetById()
    {
      var userId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> results = _kr.GetByUserId(userId);
      if (results == null)
      {
        return BadRequest();
      }
      return Ok(results);
    }



    //DELETE
    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<string> Delete(int id)
    {
      var userId = HttpContext.User.Identity.Name;
      bool successful = _kr.Delete(id, userId);
      if (!successful)
      {
        return BadRequest();
      }
      return Ok();
    }
  }
}