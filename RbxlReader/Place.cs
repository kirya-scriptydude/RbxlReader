namespace RbxlReader;

/// <summary>
/// High-Level representation of a .rbxl data.
/// </summary>
public class Place {
    public PlaceFile Rbxl;

    public Place(string path) {
        Rbxl = PlaceFile.Load(path);
    }

}

