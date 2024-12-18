namespace RbxlReader.Chunks.Unpacking;

/// <summary>
/// TODO
/// </summary>
internal class YesUnpack : IUnpackImplementaion {
    public byte[] LZ4(byte[] data) {
        return data;
    }

    public byte[] ZSTD(byte[] data) {
        return data;
    }
}