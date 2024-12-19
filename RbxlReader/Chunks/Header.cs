using System.Linq;
using RbxlReader.Utility;
namespace RbxlReader.Chunks;

/// <summary>
/// First 32 bytes of a .rbxl file. Doesn't hold much useful information, but is used to check file integrity.
/// </summary>
public class Header : IBinaryChunk {
    public ChunkHeader? BinaryHeader {get; set;}

    public static readonly char[] MAGIC_NUMBER = {'<','r','o','b','l','o','x', '!'}; //<roblox!
    public static readonly byte[] FILE_SIGNATURE = {137, 255, 13, 10, 26, 10};
    public static readonly ushort VERSION = 0;

    //Number of classes (i.e number of INST chunks)
    public int ClassCount;
    public int InstanceCount;

    public static IBinaryChunk? Parse(Stream stream) {
        Header newHeader = new();
        
        BinaryReader reader = new(stream);

        char[] magicNumber = reader.ReadChars(8);
        if (!MAGIC_NUMBER.SequenceEqual(magicNumber)) return null;

        byte[] signature = reader.ReadBytes(6);
        if (!FILE_SIGNATURE.SequenceEqual(signature)) return null;

        ushort version = reader.ReadUInt16();
        if (version != VERSION) return null;

        newHeader.ClassCount = reader.ReadInt32();
        newHeader.InstanceCount = reader.ReadInt32();
        reader.ReadBytes(8);

        return newHeader;
    }
}