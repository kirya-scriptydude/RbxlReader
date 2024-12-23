using RbxlReader.Chunks.Unpacking;

namespace RbxlReader.Chunks;

/// <summary>
/// The Shared String chunk (SSTR) is an array of strings. It’s used to reduce the overall size of a file by allowing large strings to be reused in PROP chunks.
/// </summary>
public class SSTR : IBinaryChunk {
    public static IBinaryChunk? Parse(Stream stream, ChunkHeader? header = null) {
        if (header == null) return null;
        
        byte[] data = Unpack.GetUncompressedBytes(stream, header);

        return new SSTR();
    }
}