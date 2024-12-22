namespace RbxlReader.Chunks;

public class META : IBinaryChunk {
    public static IBinaryChunk Parse(Stream stream) {
        return new META();
    }
}