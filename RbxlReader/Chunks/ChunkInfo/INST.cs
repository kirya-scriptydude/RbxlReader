using RbxlReader.Chunks;

public class INST : IChunkInfo {
    public BinaryChunkData Raw {get; set;}

    public string ClassName {get; protected set;} = "";
    public bool IsService { get; protected set; }
    public int Index {get; protected set;}

    public int InstanceCount {get; protected set;}
    public List<int> InstanceIds {get; protected set;}

    public List<bool>? RootedServices;

    public INST(BinaryChunkData raw, bool loadNow = true) {
        Raw = raw;

        if (!loadNow) return;

        using (MemoryStream stream = new(raw.Data)) {
            Load(new RbxlBinaryReader(stream));
        }
    }

    public void Load(RbxlBinaryReader reader) {
        Index = reader.ReadInt32();
        ClassName = reader.ReadString();
        IsService = reader.ReadBoolean();

        InstanceCount = reader.ReadInt32();
        InstanceIds = reader.ReadInstanceIds(InstanceCount);

        if (IsService) {
            RootedServices = new List<bool>();

            for (int i = 0; i < InstanceCount; i++) {
                bool isRoot = reader.ReadBoolean();
                RootedServices.Add(isRoot);
            }
        }
        
    }
}