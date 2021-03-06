using System.Data.Entity;
using WebApiTokenAuthentication.Models;

namespace WebApiTokenAuthentication.Data
{
    public class DALBase : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        //
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public DALBase() : base("name=WebApiTokenAuthenticationContext")
        {
        }

        public System.Data.Entity.DbSet<APIVoucherUpdateControls> APIVoucherUpdateControls { get; set; }
        public System.Data.Entity.DbSet<BO_PAYABLES> BO_PAYABLES { get; set; }

        public System.Data.Entity.DbSet<BO_RECEIVABLES> BO_RECEIVABLES { get; set; }

    }
}