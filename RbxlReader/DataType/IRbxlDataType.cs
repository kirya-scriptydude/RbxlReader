using RbxlReader.Chunks;
namespace RbxlReader.DataTypes;

public interface IRbxlDataType {
    public void Read(RbxlBinaryReader reader);
}