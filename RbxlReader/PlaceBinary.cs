#pragma warning disable SYSLIB0001 // Type or member is obsolete. Need to be using UTF-7

using System.Text;
namespace RbxlReader;

/// <summary>
/// Low-level .rbxl file representation
/// </summary>
public class PlaceBinary {

    public static readonly string MAGIC_HEADER = "<roblox!\x89\xff\x0d\x0a\x1a\x0a";

    public ushort Version {get; protected set;}
    public int NumberClasses {get; protected set;}
    public int NumberInstances {get; protected set;}
    public long Reserved {get; protected set;}

    /// <summary>
    /// Create class and parse from file
    /// </summary>
    /// <param name="path"></param>
    public PlaceBinary(string path) {
        using (FileStream file = File.Open(path, FileMode.Open)) {
            parseHeader(file);
        }
    }

    /// <summary>
    /// Create empty PlaceBinary
    /// </summary>
    public PlaceBinary() {}

    private void parseHeader(Stream stream) {
        BinaryReader reader = new(stream);

        byte[] signature = reader.ReadBytes(14);
        string signatureString = Encoding.UTF7.GetString(signature);

        if (signatureString != MAGIC_HEADER) throw new InvalidDataException("Data signature does not match file header!");

        Version = reader.ReadUInt16();
        NumberClasses = reader.ReadInt32();
        NumberInstances = reader.ReadInt32();
        Reserved = reader.ReadInt64();
    }
}