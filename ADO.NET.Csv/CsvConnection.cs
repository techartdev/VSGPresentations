using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.Csv
{
    public class CsvConnection : DbConnection, IDbConnection
    {
        private string _connectionString;
        private ConnectionState _state;
        private CsvTransaction _transaction;

        public CsvConnection(string connectionString)
        {
            _connectionString = connectionString;
            _state = ConnectionState.Closed;
        }

        public override string ConnectionString
        {
            get => _connectionString;
            set
            {
                if (_state == ConnectionState.Open)
                {
                    throw new InvalidOperationException("Cannot change the connection string while the connection is open.");
                }
                _connectionString = value;
            }
        }

        public override string Database => "CSV";

        public override string DataSource => "";

        public override string ServerVersion => "";

        public override ConnectionState State => _state;

        public override void ChangeDatabase(string databaseName)
        {
            throw new NotSupportedException("CSV files do not support multiple databases.");
        }

        public override void Close()
        {
            throw new NotSupportedException();
        }

        public override void Open()
        {
            throw new NotSupportedException();
        }

        public override DataTable GetSchema()
        {
            throw new NotSupportedException();
        }

        public override DataTable GetSchema(string collectionName)
        {
            throw new NotSupportedException();
        }

        public override DataTable GetSchema(string collectionName, string[] restrictionValues)
        {
            throw new NotSupportedException();
        }

        protected override DbTransaction BeginDbTransaction(IsolationLevel isolationLevel)
        {
            throw new NotSupportedException();
        }

        protected override DbCommand CreateDbCommand()
        {
            return new CsvCommand(this);
        }
    }
}
