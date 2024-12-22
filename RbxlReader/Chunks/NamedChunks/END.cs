namespace RbxlReader.Chunks;

public class END : IBinaryChunk {
    public static IBinaryChunk Parse(Stream stream) {
        return new END();
    }
}