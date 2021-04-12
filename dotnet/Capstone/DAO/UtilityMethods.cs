using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DAO
{
    public static class UtilityMethods
    {
        public static SqlParameter AddWithNullableValue(
            this SqlParameterCollection collection,
            string parameterName,
            object value)
        {
            if (value == null)
                return collection.AddWithValue(parameterName, DBNull.Value);
            else
                return collection.AddWithValue(parameterName, value);
        }
    }
}
