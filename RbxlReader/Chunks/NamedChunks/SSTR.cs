namespace RbxlReader.Chunks;

public class SSTR : IBinaryChunk {
    public static IBinaryChunk Parse(Stream stream, ChunkHeader? header = null) {
        return new SSTR();
    }
}