namespace RbxlReader.Chunks;

public class PROP : IBinaryChunk {
    public static IBinaryChunk Parse(Stream stream, ChunkHeader? header = null) {
        return new PROP();
    }
}