using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepRepository _vkr;
    public VaultKeepsController(VaultKeepRepository vkr)
    {
      _vkr = vkr;
    }
    //GETALL
    [HttpGet]
    public ActionResult<IEnumerable<VaultKeepsController>> Get()
    {
      IEnumerable<VaultKeep> results = _vkr.GetALL();
      if (results == null)
      {
        return BadRequest();
      }
      return Ok(results);
    }
    //GETBYID
    [HttpGet("{id}")]
    public ActionResult<VaultKeep> GetById(int id)
    {
      VaultKeep found = _vkr.GetById(id);
      if (found == null)
      {
        return BadRequest();
      }
      return Ok(found);
    }
    //GET KeepS BY VAULTKEEP ID
    [HttpGet("{id}/keeps")]
    public ActionResult<IEnumerable<VaultKeep>> GetKeeps(int id)
    {
      return Ok(_vkr.GetKeeps(id));
    }
    //CREATE
    [HttpPost]
    public ActionResult<VaultKeep> Create([FromBody] VaultKeep vaultKeeper)
    {
      VaultKeep newVaultKeeper = _vkr.CreateVaultKeep(vaultKeeper);
      if (newVaultKeeper == null)
      {
        return BadRequest("Can't create that Keep!");
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