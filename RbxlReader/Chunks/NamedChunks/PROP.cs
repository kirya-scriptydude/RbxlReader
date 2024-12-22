namespace RbxlReader.Chunks;

public class PROP : IBinaryChunk {
    public static IBinaryChunk Parse(Stream stream) {
        return new PROP();
    }
}