using RbxlReader.Chunks;

namespace RbxlReader;

/// <summary>
/// Lower-level representation of a .rbxl data. Holds information about data chunks.
/// </summary>
public class PlaceFile {

    public Header FileHeader;

    //temporary variable for testing
    public ChunkHeader ExampleChunkHeader;

    public PlaceFile(Header head, ChunkHeader headhead) {
        FileHeader = head;
        ExampleChunkHeader = headhead;
    }

    public static PlaceFile Load(string path) {
        BinaryReader reader = new(File.Open(path, FileMode.Open));

        var header = Header.Parse(reader);
        if (header == null) throw new IOException(".rbxl file header is corrupt.");
        
        var chunkHeader = ChunkHeader.Parse(reader);
        if (header == null) throw new IOException($".rbxl one of chunk headers is corrupt. Position - {reader.BaseStream.Position}");

        PlaceFile file = new(
            (Header)header,
            (ChunkHeader)chunkHeader
        );
        
        return file;
    }
}