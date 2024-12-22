namespace RbxlReader.Chunks;

public class PRNT : IBinaryChunk {
    public static IBinaryChunk Parse(Stream stream, ChunkHeader? header = null) {
        return new PRNT();
    }
}