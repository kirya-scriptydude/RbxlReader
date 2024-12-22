namespace RbxlReader.Chunks;

public class INST : IBinaryChunk {
    public static IBinaryChunk Parse(Stream stream) {
        return new INST();
    }
}