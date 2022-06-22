using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataLayer
{
    public class LicensePlateContext : IDB<LicensePlate, string>
    {
        private IzpitContext ctx;

        public LicensePlateContext()
        {
            ctx = new IzpitContext();
        }
        public void Create(LicensePlate item)
        {
            try
            {
                ctx.LicensePlates.Add(item);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public LicensePlate Read(string key)
        {
            try
            {
                return ctx.LicensePlates.Find(key);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IEnumerable<LicensePlate> ReadAll()
        {
            try
            {
                return ctx.LicensePlates.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Update(LicensePlate item)
        {
            try
            {
                LicensePlate old = Read(item.PlateNumber);
                ctx.Entry(old).CurrentValues.SetValues(item);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Delete(string key)
        {
            try
            {
                LicensePlate item = Read(key);
                ctx.LicensePlates.Remove(item);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
