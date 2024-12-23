namespace RbxlReader;

/// <summary>
/// Low-level .rbxl file representation
/// </summary>
public class PlaceBinary {

    public static readonly string MAGIC_NUMBER = "<roblox!";

    /// <summary>
    /// Create class and parse from file
    /// </summary>
    /// <param name="path"></param>
    public PlaceBinary(string path) {
    }

    /// <summary>
    /// Create empty PlaceBinary
    /// </summary>
    public PlaceBinary() {}
}