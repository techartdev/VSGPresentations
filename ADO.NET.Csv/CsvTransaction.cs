using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.Csv
{
    public class CsvTransaction : DbTransaction, IDbTransaction
    {
        private CsvConnection _connection;
        private IsolationLevel _isolationLevel;
        private string _tempFilePath;
        private bool _isCommitted;

        public string TempFilePath => _tempFilePath;

        public CsvTransaction(CsvConnection connection, IsolationLevel isolationLevel)
        {
            _connection = connection;
            _isolationLevel = isolationLevel;
            _tempFilePath = Path.GetTempFileName();
            File.Copy(connection.ConnectionString, _tempFilePath, true);
        }

        public override IsolationLevel IsolationLevel => _isolationLevel;

        protected override DbConnection DbConnection => _connection;

        public override void Commit()
        {
            if (_isCommitted)
            {
                throw new InvalidOperationException("The transaction has already been committed.");
            }

            File.Copy(_tempFilePath, _connection.ConnectionString, true);
            File.Delete(_tempFilePath);

            _isCommitted = true;
        }

        public override void Rollback()
        {
            if (_isCommitted)
            {
                throw new InvalidOperationException("The transaction has already been committed.");
            }

            _connection.Close();

            File.Delete(_tempFilePath);

            _isCommitted = true;
        }
    }
}
