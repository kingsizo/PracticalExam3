using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer;

namespace DataLayer
{
    public class KATContext : IDB<KAT, int>
    {
        private IzpitContext ctx;

        public KATContext()
        {
            ctx = new IzpitContext();
        }
        public void Create(KAT item)
        {
            try
            {
                ctx.KATs.Add(item);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public KAT Read(int key)
        {
            try
            {
                return ctx.KATs.Find(key);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public IEnumerable<KAT> ReadAll()
        {
            try
            {
                return ctx.KATs.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Update(KAT item)
        {
            try
            {
                KAT old = Read(item.KatID);
                ctx.Entry(old).CurrentValues.SetValues(item);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void Delete(int key)
        {
            try
            {
                KAT item = Read(key);
                ctx.KATs.Remove(item);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }


    }
}
