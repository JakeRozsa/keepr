using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
  public class KeepRepository
  {
    IDbConnection _db;

    public KeepRepository(IDbConnection db)
    {
      _db = db;
    }
    //CREATE
    public Keep CreateKeep(Keep keepy)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
        INSERT INTO keeps (name, description, userId, img, isPrivate, views, shares, keeps)
        VALUES  (@Name, @Description, @UserId, @Img, @IsPrivate, @Views, @Shares, @Keeps);
        SELECT LAST_INSERT_ID();", keepy);
        keepy.Id = id;
        return keepy;
      }
      catch (Exception e)
      {
        System.Console.WriteLine(e);
        return null;
      }
    }
    //GET
    public IEnumerable<Keep> GetALL()
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE isPrivate = 0");
    }
    //GETBYID
    public IEnumerable<Keep> GetByUserId(string UserId)
    {
      return _db.Query<Keep>("SELECT * FROM keeps WHERE userId =@UserId", new { UserId });
    }
    //GETKEEPSBY VAULTID
    public IEnumerable<Vault> GetKeeps(string userId)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE id = @id", new { userId });
    }
    //DELETE
    public bool Delete(int id)
    {
      int success = _db.Execute("DELETE FROM keeps WHERE id =@id", new { id });
      return success > 0;
    }
    //EDIT????

  }
}