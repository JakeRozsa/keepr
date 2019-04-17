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
        VALUES  (@KeepId, @VaultId, @UserId);
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
    //GET VAULTKeeps BY VAULT ID
    public IEnumerable<Keep> GetByVId(string userId)
    {
      return _db.Query<Keep>(@"
SELECT * FROM vaultkeeps vk
INNER JOIN keeps k ON k.id = vk.keepId
WHERE(vaultId = @vaultId AND vk.userId = @UserId)
", new { userId });
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