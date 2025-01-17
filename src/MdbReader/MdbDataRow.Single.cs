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

    private float GetSingle(IMdbValue fieldValue) => fieldValue switch
    {
        MdbSingleValue singleValue => singleValue.Value,
        _ => ThrowInvalidCast<float>(fieldValue, nameof(Single))
    };

    /// <summary>
    /// Gets the value of the specified column as a Single.
    /// </summary>
    /// <param name="index">The zero-based column ordinal.</param>
    /// <returns>The value of the column.</returns>
    /// <throws cref="InvalidCastException">The specified cast is not valid.</throws>
    /// <remarks>
    /// <para>
    /// No conversions are performed; therefore, the column must be a <see cref="MdbColumnType.Single"/>,
    /// otherwise an exception is generated.
    /// </para>
    /// <para>For nullable columns, call <see cref="IsNull(int)"/> to check for null values before calling this method.
    /// This method throws when trying to return a null value.</para>
    /// </remarks>
    public float GetSingle(int index)
    {
        var fieldValue = GetFieldValue(index);
        ThrowIfNullCast(fieldValue, nameof(Single));
        return GetSingle(fieldValue);
    }

    /// <summary>
    /// Gets the value of the specified column as a Single.
    /// </summary>
    /// <param name="columnName">The column name (case sensitive).</param>
    /// <returns>The value of the column.</returns>
    /// <throws cref="InvalidCastException">The specified cast is not valid.</throws>
    /// <remarks>
    /// <para>
    /// No conversions are performed; therefore, the column must be a <see cref="MdbColumnType.Single"/>,
    /// otherwise an exception is generated.
    /// </para>
    /// <para>For nullable columns, call <see cref="IsNull(int)"/> to check for null values before calling this method.
    /// This method throws when trying to return a null value.</para>
    /// </remarks>
    public float GetSingle(string columnName)
    {
        var fieldValue = GetFieldValue(columnName);
        ThrowIfNullCast(fieldValue, nameof(Single));
        return GetSingle(fieldValue);
    }

    /// <summary>
    /// Gets the value of the specified column as a nullable Single.
    /// </summary>
    /// <param name="index">The zero-based column ordinal.</param>
    /// <returns>The value of the column.</returns>
    /// <throws cref="InvalidCastException">The specified cast is not valid.</throws>
    /// <remarks>
    /// <para>
    /// No conversions are performed; therefore, the column must be a <see cref="MdbColumnType.Single"/>,
    /// otherwise an exception is generated.
    /// </para>
    /// </remarks>
    public float? GetNullableSingle(int index)
    {
        var fieldValue = GetFieldValue(index);
        return fieldValue.IsNull ? null : GetSingle(fieldValue);
    }

    /// <summary>
    /// Gets the value of the specified column as a nullable Single.
    /// </summary>
    /// <param name="columnName">The column name (case sensitive).</param>
    /// <returns>The value of the column.</returns>
    /// <throws cref="InvalidCastException">The specified cast is not valid.</throws>
    /// <remarks>
    /// <para>
    /// No conversions are performed; therefore, the column must be a <see cref="MdbColumnType.Single"/>,
    /// otherwise an exception is generated.
    /// </para>
    /// </remarks>
    public float? GetNullableSingle(string columnName)
    {
        var fieldValue = GetFieldValue(columnName);
        return fieldValue.IsNull ? null : GetSingle(fieldValue);
    }
}

