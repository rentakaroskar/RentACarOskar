using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarOskar
{
   public interface PropertyInterface
    {
        string GetSelectQuery();
        string GetInsertQuery();
        string GetUpdateQuery();
        string GetDeleteQuery();
        string GetLookupQuery(string ID);

        List<SqlParameter> GetInsertParameters();
        List<SqlParameter> GetUpdateParameters();
        List<SqlParameter> GetDeleteParameters();
    }
}
