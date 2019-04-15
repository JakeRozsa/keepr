using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VaultsController : ControllerBase
  {
    private readonly VaultRepository _vr;
    public VaultsController(VaultRepository vr)
    {
      _vr = vr;
    }
    //GETALL
    [HttpGet]
    public ActionResult<IEnumerable<VaultsController>> Get()
    {
      IEnumerable<Vault> results = _vr.GetALL();
      if (results == null)
      {
        return BadRequest();
      }
      return Ok(results);
    }
    //GETBYID
    [HttpGet("{id}")]
    public ActionResult<Vault> GetByVId(int id)
    {
      Vault found = _vr.GetByVId(id);
      if (found == null)
      {
        return BadRequest();
      }
      return Ok(found);
    }
    //GET VAULTS BY KEEP ID
    [HttpGet("{id}/keeps")]
    public ActionResult<IEnumerable<Vault>> GetVaults(int id)
    {
      return Ok(_vr.GetVaults(id));
    }
    //CREATE
    [HttpPost]
    public ActionResult<Vault> Create([FromBody] Vault vaulty)
    {
      Vault newVaulty = _vr.CreateVault(vaulty);
      if (newVaulty == null)
      {
        return BadRequest("Can't create that Keep!");
      }
      return Ok(newVaulty);
    }
    //DELETE
    [HttpDelete]
    public ActionResult<string> Delete(int id)
    {
      bool successful = _vr.Delete(id);
      if (!successful)
      {
        return BadRequest();
      }
      return Ok();
    }
  }
}