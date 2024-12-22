namespace RbxlReader.Chunks;

public class INST : IBinaryChunk {
    public static IBinaryChunk Parse(Stream stream, ChunkHeader? header = null) {
        return new INST();
    }
}