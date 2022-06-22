using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer
{
    public static class DBContextManager
    {
        public static DriversLicenseContext GetDriversLicenseContext() => new DriversLicenseContext();
        public static KATContext GetKATContext() => new KATContext();
        public static LicensePlateContext GetLicensePlateContext() => new LicensePlateContext();

    }
}