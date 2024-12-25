using System.Text;
namespace RbxlReader.Chunks;

/// <summary>
/// Binary Reader best suited for reading .rbxl files.
/// 
/// Credits to Roblox-File-Format (MIT) repo. By CloneTrooper1019 (MaximumADHD)
/// </summary>
public class RbxlBinaryReader(Stream stream) : BinaryReader(stream) {
     public override string ReadString() {
        int length = ReadInt32();
        byte[] buffer = ReadBytes(length);

        return Encoding.UTF8.GetString(buffer);
    }
}