using RbxlReader.DataTypes;

namespace RbxlReader.Chunks;

/// <summary>
/// PROP is a chunk that defines individual property and holds information about them (CFrame, Vector3 etc.) 
/// </summary>
public class PROP : IChunkInfo {
    public BinaryChunkData Raw {get; set;}

    public int ClassId {get; protected set;}
    public string PropName {get; protected set;} = "";
    public INST? Class {get; protected set;} 
    
    public PropertyType Type => (PropertyType)typeId;
    private byte typeId;

    public PROP(BinaryChunkData raw, bool loadNow = true) {
        Raw = raw;

        if (!loadNow) return;
        using (MemoryStream stream = new(raw.Data)) {
            Load(new RbxlBinaryReader(stream));
        }
    }

    public void Load(RbxlBinaryReader reader) {
        ClassId = reader.ReadInt32();
        PropName = reader.ReadString();
        typeId = reader.ReadByte();

        Class = Raw.Rbxl.IdToINST[ClassId];
        
    }
}