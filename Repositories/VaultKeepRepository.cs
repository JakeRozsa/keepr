using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class VaultKeepRepository
  {
    IDbConnection _db;

    public VaultKeepRepository(IDbConnection db)
    {
      _db = db;
    }
    //CREATE
    public VaultKeep CreateVaultKeep(VaultKeep vaultKeeper)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
        INSERT INTO vaultkeeps (keepId, vaultId, userId)
        VALUES  (@KeepId, @VaultId, UserId);
        SELECT LAST_INSERT_ID();", vaultKeeper);
        vaultKeeper.Id = id;
        return vaultKeeper;
      }
      catch (Exception e)
      {
        System.Console.WriteLine(e);
        return null;
      }
    }
    //GET
    public IEnumerable<VaultKeep> GetALL()
    {
      return _db.Query<VaultKeep>("SELECT * FROM vaultkeeps");
    }
    //GETBYID
    public VaultKeep GetByVId(int Id)
    {
      return _db.QueryFirstOrDefault<VaultKeep>("SELECT * FROM vaults WHERE id =@Id", new { Id });
    }
    //GET VAULTKeeps BY VAULT ID
    public IEnumerable<Vault> GetVaultKeeps(int id)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE id = @id", new { id });
    }
    //DELETE
    public bool Delete(int id)
    {
      int success = _db.Execute("DELETE FROM vaultkeeps WHERE id =@id", new { id });
      return success > 0;
    }
    //EDIT????

  }
}