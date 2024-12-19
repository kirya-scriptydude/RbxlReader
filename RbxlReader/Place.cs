namespace RbxlReader;

/// <summary>
/// High-Level representation of a .rbxl data.
/// </summary>
public class Place {
    public PlaceFile? Rbxl;

    /// <summary>
    /// Create new class by decoding existing .rbxl file.
    /// </summary>
    /// <param name="path">File path</param>
    public Place(string path) {
        Rbxl = PlaceFile.Load(path);
    }

    /// <summary>
    /// Create new empty class.
    /// </summary>
    public Place() {}

}

