// This file is part of MdbReader. Licensed under the LGPL version 2.0.
// You should have received a coy of the GNU LGPL version along with this
// program. If not, see https://www.gnu.org/licenses/old-licenses/lgpl-2.0.html
//
// Copyright Micah Makaiwi.
// Based on code from libmdb (https://github.com/mdbtools/mdbtools)

using MMKiwi.MdbReader.Values;

namespace MMKiwi.MdbReader;

public sealed partial class MdbDataRow
{
    private decimal GetDecimal(IMdbValue fieldValue) => fieldValue switch
    {
        MdbLongIntValue longIntValue => longIntValue.Value,
        MdbIntValue intValue => intValue.Value,
        MdbByteValue byteValue => byteValue.Value,
        MdbCurrencyValue currencyValue => currencyValue.Value,
        _ => ThrowInvalidCast<decimal>(fieldValue, nameof(Decimal))
    };

    /// <summary>
    /// Gets the value of the specified column as a decimal.
    /// </summary>
    /// <param name="index">The zero-based column ordinal.</param>
    /// <returns>The value of the column.</returns>
    /// <throws cref="InvalidCastException">The specified cast is not valid.</throws>
    /// <remarks>
    /// <para>
    /// No conversions are performed; therefore, the column must be a <see cref="MdbColumnType.Currency"/>,
    /// <see cref="MdbColumnType.LongInt"/>, <see cref="MdbColumnType.Int"/>, <see cref="MdbColumnType.Byte"/>
    /// or an exception is generated.
    /// </para>
    /// <para>For nullable columns, call <see cref="IsNull(int)"/> to check for null values before calling this method. This method throws when trying to return a null value.</para>
    /// </remarks>
    public decimal GetDecimal(int index)
    {
        var fieldValue = GetFieldValue(index);
        ThrowIfNullCast(fieldValue, nameof(Decimal));
        return GetDecimal(fieldValue);
    }

    /// <summary>
    /// Gets the value of the specified column as a decimal.
    /// </summary>
    /// <param name="columnName">The column name (case sensitive).</param>
    /// <returns>The value of the column.</returns>
    /// <throws cref="InvalidCastException">The specified cast is not valid.</throws>
    /// <remarks>
    /// <para>
    /// No conversions are performed; therefore, the column must be a <see cref="MdbColumnType.Currency"/>,
    /// <see cref="MdbColumnType.LongInt"/>, <see cref="MdbColumnType.Int"/>, <see cref="MdbColumnType.Byte"/>
    /// or an exception is generated.
    /// </para>
    /// <para>For nullable columns, call <see cref="IsNull(int)"/> to check for null values before calling this method. This method throws when trying to return a null value.</para>
    /// </remarks>
    public decimal GetDecimal(string columnName)
    {
        var fieldValue = GetFieldValue(columnName);
        ThrowIfNullCast(fieldValue, nameof(Decimal));
        return GetDecimal(fieldValue);
    }

    /// <summary>
    /// Gets the value of the specified column as a nullable decimal.
    /// </summary>
    /// <param name="index">The zero-based column ordinal.</param>
    /// <returns>The value of the column.</returns>
    /// <throws cref="InvalidCastException">The specified cast is not valid.</throws>
    /// <remarks>
    /// <para>
    /// No conversions are performed; therefore, the column must be a <see cref="MdbColumnType.Currency"/>,
    /// <see cref="MdbColumnType.LongInt"/>, <see cref="MdbColumnType.Int"/>, <see cref="MdbColumnType.Byte"/>
    /// or an exception is generated.
    /// </para>
    /// </remarks>
    public decimal? GetNullableDecimal(int index)
    {
        var fieldValue = GetFieldValue(index);
        if (fieldValue.IsNull) return null;
        return GetDecimal(fieldValue);
    }
    /// <summary>
    /// Gets the value of the specified column as a nullable decimal.
    /// </summary>
    /// <param name="columnName">The column name (case sensitive).</param>
    /// <returns>The value of the column.</returns>
    /// <throws cref="InvalidCastException">The specified cast is not valid.</throws>
    /// <remarks>
    /// <para>
    /// No conversions are performed; therefore, the column must be a <see cref="MdbColumnType.Currency"/>,
    /// <see cref="MdbColumnType.LongInt"/>, <see cref="MdbColumnType.Int"/>, <see cref="MdbColumnType.Byte"/>
    /// or an exception is generated.
    /// </para>
    /// </remarks>
    public decimal? GetNullableDecimal(string columnName)
    {
        var fieldValue = GetFieldValue(columnName);
        if (fieldValue.IsNull) return null;
        return GetDecimal(fieldValue);
    }

}

