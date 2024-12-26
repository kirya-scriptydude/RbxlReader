using RbxlReader.Chunks;

public class INST : IChunkInfo {
    public BinaryChunkData Raw {get; set;}

    public string ClassName {get; protected set;} = "";
    public bool IsService { get; protected set; }
    public int Index {get; protected set;}

    public int InstanceCount {get; protected set;}
    public List<int> InstanceId {get; protected set;}


    public INST(BinaryChunkData raw, bool loadNow = true) {
        Raw = raw;

        if (!loadNow) return;

        using (MemoryStream stream = new(raw.Data)) {
            Load(new RbxlBinaryReader(stream));
        }
    }

    public void Load(RbxlBinaryReader reader) { 
    }
}