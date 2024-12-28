using RbxlReader.Chunks;

namespace RbxlReader;

public struct ChunkStruct {
    public META? META;
    public Dictionary<string, INST> INST = new();

    public ChunkStruct() {}
}