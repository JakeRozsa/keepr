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
        INSERT INTO vaults (name, description, userId)
        VALUES  (@Name, @Description, @UserId);
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
    public IEnumerable<Vault> GetByUserId(string UserId)
    {
      //get WHERE UserId = @UserId
      return _db.Query<Vault>("SELECT * FROM vaults WHERE userId = @UserId;", new { UserId });
    }
    //GET VAULT BY KEEP ID
    public IEnumerable<Vault> GetVaults(int id)
    {
      return _db.Query<Vault>("SELECT * FROM keeps WHERE id = @id", new { id });
    }
    //DELETE
    public bool Delete(int id, string userId)
    {
      int success = _db.Execute("DELETE FROM vaults WHERE id =@id AND userId = @userId", new { id, userId });
      return success > 0;
    }
    //EDIT????

  }
}