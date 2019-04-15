using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultRepository
  {
    IDbConnection _db;

    public VaultRepository(IDbConnection db)
    {
      _db = db;
    }
    //CREATE
    public Vault CreateVault(Vault vaulty)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
        INSERT INTO vaults (name, description)
        VALUES  (@Name, @Description);
        SELECT LAST_INSERT_ID();", vaulty);
        vaulty.Id = id;
        return vaulty;
      }
      catch (Exception e)
      {
        System.Console.WriteLine(e);
        return null;
      }
    }
    //GET
    public IEnumerable<Vault> GetALL()
    {
      return _db.Query<Vault>("SELECT * FROM vaults");
    }
    //GETBYID
    public Vault GetById(int Id)
    {
      return _db.QueryFirstOrDefault<Vault>("SELECT * FROM vaults WHERE id =@Id", new { Id });
    }
    //GET VAULT BY KEEP ID
    public IEnumerable<Vault> GetVaults(int id)
    {
      return _db.Query<Vault>("SELECT * FROM keeps WHERE id = @id", new { id });
    }
    //DELETE
    public bool Delete(int id)
    {
      int success = _db.Execute("DELETE FROM vaults WHERE id =@id", new { id });
      return success > 0;
    }
    //EDIT????

  }
}