namespace RbxlReader.Chunks;

public class SSTR : IBinaryChunk {
    public static IBinaryChunk Parse(Stream stream) {
        return new SSTR();
    }
}