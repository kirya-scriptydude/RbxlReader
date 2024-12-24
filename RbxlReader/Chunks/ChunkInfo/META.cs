using System.Text;
namespace RbxlReader.Chunks;

public class META : IChunkInfo {
    public BinaryChunkData Raw {get; set;}
    public Dictionary<string, string> Table = new();

    public META(BinaryChunkData raw) {
        Raw = raw;

        using (MemoryStream stream = new(raw.Data)) {
            Load(stream);
        }
    }

    public void Load(MemoryStream stream) {
        BinaryReader reader = new(stream);

        int count = reader.ReadInt32();

        for (int i = 0; i > count; i++) {
            string key = reader.ReadString();
            string value = reader.ReadString();
            Table.Add(key, value);
        }

        Raw.Rbxl.METAChunk = this;
    }
}