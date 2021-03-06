﻿namespace Code4Bugs.SimpleDataGridViewPaging.Statement.Builder
{
    /// <summary>
    /// Queries data rows of the table.
    /// </summary>
    public class RowsStatementBuilder : StatementBuilder<object>
    {
        protected int _maxRecords;
        protected int _pageOffset;

        public RowsStatementBuilder MaxRecords(int maxRecords)
        {
            _maxRecords = maxRecords;
            return this;
        }

        public RowsStatementBuilder PageOffset(int pageOffset)
        {
            _pageOffset = pageOffset;
            return this;
        }

        protected string GetCommandText()
        {
            return string.IsNullOrEmpty(_commandText)
                ? $"SELECT * FROM {_tableName} LIMIT {_maxRecords} OFFSET {_pageOffset}"
                : string.Format(_commandText, _tableName, _maxRecords, _pageOffset);
        }

        public override IStatement<object> Build()
        {
            return new ReaderStatement(_connection, GetCommandText());
        }
    }
}