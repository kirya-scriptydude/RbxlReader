using RbxlReader.Chunks;

public class PRNT : IChunkInfo {
    public BinaryChunkData Raw {get; set;}

    public byte Version {get; protected set;}
    public int InstanceCount {get; protected set;}


    public PRNT(BinaryChunkData raw, bool loadNow = true) {
        Raw = raw;

        if (!loadNow) return;
        using (MemoryStream stream = new(raw.Data)) {
            Load(new RbxlBinaryReader(stream));
        }
    }

    public void Load(RbxlBinaryReader reader) {
        Version = reader.ReadByte();
        InstanceCount = reader.ReadInt32();

        List<int> childIds = reader.ReadInstanceIds(InstanceCount);
        List<int> parentIds = reader.ReadInstanceIds(InstanceCount);
    }
}