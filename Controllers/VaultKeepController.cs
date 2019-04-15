using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

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
    //GETALL
    [HttpGet]
    public ActionResult<IEnumerable<VaultkeepsController>> Get()
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
    public ActionResult<VaultKeep> GetByVId(int id)
    {
      VaultKeep found = _vkr.GetByVId(id);
      if (found == null)
      {
        return BadRequest();
      }
      return Ok(found);
    }
    //GET VAULTKEEPSS BY VAULTKEEP ID
    [HttpGet("{id}/vaultkeeps")]
    public ActionResult<IEnumerable<VaultKeep>> GetKeeps(int id)
    {
      return Ok(_vkr.GetVaultKeeps(id));
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