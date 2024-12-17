namespace RbxlReader;

/// <summary>
/// High-Level representation of a .rbxl data.
/// </summary>
public class Place {
    public PlaceFile Rbxl;

    private string _filePath;


    public Place(string path) {
        _filePath = path;
        Rbxl = PlaceFile.Load(path);
    }

}

