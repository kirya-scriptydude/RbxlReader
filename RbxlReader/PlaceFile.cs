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

        bool endReached = false;
        while (!endReached) {
            
            ChunkHeader header = (ChunkHeader)ChunkHeader.Parse(stream);

            switch(new string(header.ChunkName)) {
                case "META":
                    addChunk<META>(header, chunks, stream);
                    break;
                case "SSTR":
                    addChunk<SSTR>(header, chunks, stream);
                    break;
                case "INST":
                    addChunk<INST>(header, chunks, stream);
                    break;
                case "PRNT":
                    addChunk<PRNT>(header, chunks, stream);
                    break;
                case "END\0":
                    endReached = true;
                    break;
            }
        }

        return chunks;
    }

    /// <summary>
    /// Add and then parse a chunk
    /// </summary>
    private static void addChunk<T>(ChunkHeader header, List<ChunkPair> chunks, Stream stream) where T : IBinaryChunk {
        IBinaryChunk? chunk = T.Parse(stream, header);

        if (chunk == null) 
            throw new NullReferenceException($"chunk didn't parse: {new string(header.ChunkName)} at position {stream.Position}");
        
        chunks.Add(new ChunkPair(header, chunk));
    }
}