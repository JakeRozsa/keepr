using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultkeepsController : ControllerBase
  {
    private readonly VaultKeepRepository _vkr;
    public VaultkeepsController(VaultKeepRepository vkr)
    {
      _vkr = vkr;
    }

    //GETBYVAULTID
    [Authorize]
    [HttpGet("vaults/{vaultId}")]
    public ActionResult<IEnumerable<VaultKeep>> GetByVId(int vaultId)
    {
      var userId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> results = _vkr.GetByVId(vaultId, userId);
      if (results == null)
      {
        return BadRequest();
      }
      return Ok(results);
    }

    //CREATE
    [Authorize]
    [HttpPost]
    public ActionResult<VaultKeep> Create([FromBody] VaultKeep vaultKeeper)
    {
      vaultKeeper.UserId = HttpContext.User.Identity.Name;
      VaultKeep newVaultKeeper = _vkr.CreateVaultKeep(vaultKeeper);
      if (newVaultKeeper == null)
      {
        return BadRequest("Can't create that VAULTKeep!");
      }
      return Ok(newVaultKeeper);
    }
    //DELETE
    [HttpDelete]
    public ActionResult<string> Delete(int id)
    {
      bool successful = _vkr.Delete(id);
      if (!successful)
      {
        return BadRequest();
      }
      return Ok();
    }
  }
}