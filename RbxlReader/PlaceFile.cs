using RbxlReader.Chunks;

namespace RbxlReader;

/// <summary>
/// Lower-level representation of a .rbxl data. Holds information about data chunks.
/// </summary>
public class PlaceFile {

    public static readonly char[] END_NAME_SEQUENCE = {'E', 'N', 'D', '\0'};

    public Header FileHeader;
    public List<ChunkPair> Chunks { get; protected set; }

    public PlaceFile(Header head, List<ChunkPair> chunks) {
        FileHeader = head;
        Chunks = chunks;
    }

    public static PlaceFile Load(string path) {
        FileStream reader = File.Open(path, FileMode.Open);

        var header = Header.Parse(reader);
        if (header == null) throw new IOException(".rbxl file header is corrupt.");

        List<ChunkPair> chunks = parseChunks(reader);

        PlaceFile file = new(
            (Header)header,
            chunks
        );
        
        return file;
    }

    private static List<ChunkPair> parseChunks(Stream stream) {
        List<ChunkPair> chunks = new List<ChunkPair>(1500);

        //delete later when actual chunk parsing is done
        BinaryReader reader = new(stream);

        bool endReached = false;
        while (!endReached) {
            
            ChunkHeader header = (ChunkHeader)ChunkHeader.Parse(stream);
            uint chunkLength = header.IsCompressed ? header.CompressedLength : header.UncompressedLength;
            
            reader.ReadBytes((int)chunkLength);

            chunks.Add(
                //adding empty IBinaryChunk class for testing purposes, TODO parse actual data
                new ChunkPair(header, new Header())
            );

            if (header.ChunkName.SequenceEqual(END_NAME_SEQUENCE)) endReached = true;
        }

        return chunks;
    }
}