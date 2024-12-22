namespace RbxlReader.Chunks;

public class PRNT : IBinaryChunk {
    public static IBinaryChunk Parse(Stream stream) {
        return new PRNT();
    }
}