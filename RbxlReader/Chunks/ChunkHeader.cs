namespace RbxlReader.Chunks;

public class ChunkHeader : IChunk {
    
    public char[] ChunkName;

    public bool IsCompressed;
    public uint CompressedLength;
    public uint UncompressedLength;
    
    private ChunkHeader(char[] name) {
        ChunkName = name;
    }

    public static IChunk Parse(BinaryReader reader) {
        char[] name = reader.ReadChars(4);

        uint compressed = reader.ReadUInt32();
        uint uncompressed = reader.ReadUInt32();
        reader.ReadBytes(4); //Skip 4 reserved bytes.
        
        ChunkHeader chHeader = new(name);
        chHeader.CompressedLength = compressed;
        chHeader.UncompressedLength = uncompressed;
        if (compressed != 0) chHeader.IsCompressed = true;

        return chHeader;
    }
}