using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataLayer
{
    public class DriversLicenseContext : IDB<DriversLicense, string>
    {
        private IzpitContext ctx;

        public DriversLicenseContext()
        {
            ctx = new IzpitContext();
        }
        public void Create(DriversLicense item)
        {
            try
            {
                ctx.DriversLicenses.Add(item);
                ctx.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public DriversLicense Read(string key)
        {
            try
            {
                 return ctx.DriversLicenses.Find(key);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public IEnumerable<DriversLicense> ReadAll()
        {
            try
            {
                return ctx.DriversLicenses.ToList();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public void Update(DriversLicense item)
        {
            try
            {
                DriversLicense oldgame = Read(item.ID);
                ctx.Entry(oldgame).CurrentValues.SetValues(item);
                ctx.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public void Delete(string key)
        {
            try
            {
                DriversLicense game = Read(key);
                ctx.DriversLicenses.Remove(game);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        
    }
}
