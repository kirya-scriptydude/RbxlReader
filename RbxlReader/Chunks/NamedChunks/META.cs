namespace RbxlReader.Chunks;

public class META : IBinaryChunk {
    public static IBinaryChunk Parse(Stream stream, ChunkHeader? header = null) {
        return new META();
    }
}