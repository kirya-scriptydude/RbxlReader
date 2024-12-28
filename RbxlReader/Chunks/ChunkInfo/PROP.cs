namespace RbxlReader.Chunks;

public class PROP : IChunkInfo {
    public BinaryChunkData Raw {get; set;}

    public int ClassId {get; protected set;}
    public string ClassName {get; protected set;} = "";
    
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
        ClassName = reader.ReadString();
        typeId = reader.ReadByte();
    }
}