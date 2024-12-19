using RbxlReader.Chunks;

namespace RbxlReader;

/// <summary>
/// Lower-level representation of a .rbxl data. Holds information about data chunks.
/// </summary>
public class PlaceFile {

    public Header FileHeader;

    public PlaceFile(Header head) {
        FileHeader = head;
    }

    public static PlaceFile Load(string path) {
        FileStream reader = File.Open(path, FileMode.Open);

        var header = Header.Parse(reader);
        if (header == null) throw new IOException(".rbxl file header is corrupt.");

        PlaceFile file = new(
            (Header)header
        );
        
        return file;
    }
}