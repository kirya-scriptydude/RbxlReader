namespace RbxlReader.Chunks;

public interface IBinaryChunk {
    /// <summary>
    /// Try to parse binary data chunk. If failed return null.
    /// </summary>
    /// <param name="reader">Active binary reader instance.</param>
    /// <returns></returns>
    static abstract IBinaryChunk? Parse(Stream stream);
}