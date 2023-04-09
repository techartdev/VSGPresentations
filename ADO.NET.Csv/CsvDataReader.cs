using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper.Configuration;
using CsvHelper;
using System.IO;

namespace ADO.NET.Csv
{
    public class CsvDataReader : DbDataReader
    {
        private readonly DataTableReader _innerReader;
        private readonly string _tempFileName;
        private readonly bool _isTemp;
        private readonly CsvTransaction _transaction;
        private bool _closed;

        public CsvDataReader(DataTableReader innerReader, string tempFileName = null, bool isTemp = false,
            CsvTransaction transaction = null)
        {
            _innerReader = innerReader;
            _tempFileName = tempFileName;
            _isTemp = isTemp;
            _transaction = transaction;
        }

        public override int FieldCount => _innerReader.FieldCount;

        public override object this[int ordinal] => _innerReader[ordinal];

        public override object this[string name] => _innerReader[name];

        public override int Depth => _innerReader.Depth;

        public override bool IsClosed => _closed;

        public override int RecordsAffected => _innerReader.RecordsAffected;

        public override bool HasRows => _innerReader.HasRows;

        public override bool GetBoolean(int ordinal) => _innerReader.GetBoolean(ordinal);

        public override byte GetByte(int ordinal) => _innerReader.GetByte(ordinal);

        public override long GetBytes(int ordinal, long dataOffset, byte[] buffer, int bufferOffset, int length) =>
            _innerReader.GetBytes(ordinal, dataOffset, buffer, bufferOffset, length);

        public override char GetChar(int ordinal) => _innerReader.GetChar(ordinal);

        public override long GetChars(int ordinal, long dataOffset, char[] buffer, int bufferOffset, int length) =>
            _innerReader.GetChars(ordinal, dataOffset, buffer, bufferOffset, length);

        public override string GetDataTypeName(int ordinal) => _innerReader.GetDataTypeName(ordinal);

        public override DateTime GetDateTime(int ordinal) => _innerReader.GetDateTime(ordinal);

        public override decimal GetDecimal(int ordinal) => _innerReader.GetDecimal(ordinal);

        public override double GetDouble(int ordinal) => _innerReader.GetDouble(ordinal);

        public override IEnumerator GetEnumerator() => _innerReader.GetEnumerator();

        public override Type GetFieldType(int ordinal) => _innerReader.GetFieldType(ordinal);

        public override float GetFloat(int ordinal) => _innerReader.GetFloat(ordinal);

        public override Guid GetGuid(int ordinal) => _innerReader.GetGuid(ordinal);

        public override short GetInt16(int ordinal) => _innerReader.GetInt16(ordinal);

        public override int GetInt32(int ordinal) => _innerReader.GetInt32(ordinal);

        public override long GetInt64(int ordinal) => _innerReader.GetInt64(ordinal);

        public override string GetName(int ordinal) => _innerReader.GetName(ordinal);

        public override int GetOrdinal(string name) => _innerReader.GetOrdinal(name);

        public override DataTable GetSchemaTable() => _innerReader.GetSchemaTable();

        public override string GetString(int ordinal) => _innerReader.GetString(ordinal);

        public override object GetValue(int ordinal) => _innerReader.GetValue(ordinal);

        public override int GetValues(object[] values) => _innerReader.GetValues(values);

        public override bool IsDBNull(int ordinal) => _innerReader.IsDBNull(ordinal);

        public override bool NextResult() => _innerReader.NextResult();

        public override bool Read() => _innerReader.Read();

        public override void Close()
        {
            throw new NotSupportedException();
        }

        protected override void Dispose(bool disposing)
        {
            throw new NotSupportedException();
        }
    }
}
