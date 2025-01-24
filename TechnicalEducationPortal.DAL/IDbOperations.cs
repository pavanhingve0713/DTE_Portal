using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalEducationPortal.DAL
{
    public interface IDbOperations
    {
        public void Update(string commandText, CommandType commandType, IDbDataParameter[] parameters);
        public int Insert(string commandText, CommandType commandType, IDbDataParameter[] parameters, out int id);
        public int InsertwithUserDefineTableType(string commandText, CommandType commandType, IDbDataParameter[] parameters, string TableParam, DataTable TableType);
        public void Insert(string commandText, CommandType commandType, IDbDataParameter[] parameters);
        public void InsertUDTableType(string commandText, CommandType commandType, IDbDataParameter[] parameters, string TableParam, DataTable TableType);
        public void UpdateWithUserDefineTableType(string commandText, CommandType commandType, IDbDataParameter[] parameters, string TableParam, DataTable TableType);
        public object GetScalarValue(string commandText, CommandType commandType, IDbDataParameter[]? parameters = null);
        public DataTable GetDataTable(string commandText, CommandType commandType, IDbDataParameter[]? parameters = null);
        public DataSet GetDataSet(string commandText, CommandType commandType, IDbDataParameter[]? parameters = null);
        public DataTable InsertWithReturnRecord(string commandText, CommandType commandType, IDbDataParameter[] parameters);
        public void Delete(string commandText, CommandType commandType, IDbDataParameter[]? parameters = null);
    }
}
