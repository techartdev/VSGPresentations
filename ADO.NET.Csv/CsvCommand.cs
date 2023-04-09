using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;

namespace ADO.NET.Csv
{
    public class CsvCommand : DbCommand, IDbCommand
    {
        private CsvConnection _connection;
        private CsvTransaction _transaction;
        private string _commandText;
        private List<DbParameter> _parameters;

        public CsvCommand(CsvConnection connection)
        {
            _connection = connection;
            _parameters = new List<DbParameter>();
        }

        public override string CommandText
        {
            get => _commandText;
            set => _commandText = value;
        }

        public override int CommandTimeout { get; set; }

        public override CommandType CommandType { get; set; }

        public override bool DesignTimeVisible { get; set; }

        public override UpdateRowSource UpdatedRowSource { get; set; }

        protected override DbConnection DbConnection
        {
            get => _connection;
            set => _connection = (CsvConnection) value;
        }

        protected override DbParameterCollection DbParameterCollection { get; }

        protected override DbTransaction DbTransaction
        {
            get => _transaction;
            set => _transaction = (CsvTransaction) value;
        }

        public override void Cancel()
        {
            throw new NotSupportedException();
        }

        public override int ExecuteNonQuery()
        {
            throw new NotSupportedException();
        }

        public override object ExecuteScalar()
        {
            throw new NotSupportedException();
        }

        public override void Prepare()
        {
            throw new NotSupportedException();
        }

        protected override DbParameter CreateDbParameter()
        {
            throw new NotSupportedException();
        }

        protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
        {
            throw new NotSupportedException();
        }

        private int ExecuteInsert(string query)
        {
            throw new NotSupportedException();
        }

        private int ExecuteUpdate(string query)
        {
            throw new NotSupportedException();
        }

        private int ExecuteDelete(string query)
        {
            throw new NotSupportedException();
        }

        private void ExecuteSelect(string query)
        {
            throw new NotSupportedException();
        }
    }
}