using RbxlReader.Chunks.Unpacking;

namespace RbxlReader.Chunks;

public class PROP : IBinaryChunk {
    public static IBinaryChunk? Parse(Stream stream, ChunkHeader? header = null) {
        if (header == null) return null;
        
        byte[] data = Unpack.GetUncompressedBytes(stream, header);

        return new PROP();
    }
}