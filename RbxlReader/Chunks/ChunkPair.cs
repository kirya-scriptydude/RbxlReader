namespace RbxlReader.Chunks;

/// <summary>
/// Pair of Header + Value that forms the chunk itself.
/// </summary>
public struct ChunkPair {
    /// <summary>
    /// The header that gives context about next chunk.
    /// </summary>
    public ChunkHeader Header;
    /// <summary>
    /// The chunk itself.
    /// </summary>
    public IBinaryChunk Value;

    public ChunkPair(ChunkHeader header, IBinaryChunk chunk) {
        Header = header;
        Value = chunk;
    }
}