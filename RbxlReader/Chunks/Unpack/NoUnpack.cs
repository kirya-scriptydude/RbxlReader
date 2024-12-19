namespace RbxlReader.Chunks.Unpacking;

/// <summary>
/// Don't use any external libraries and don't unpack at all.
/// </summary>
internal class NoUnpack : IUnpackImplementaion {
    public byte[] LZ4(byte[] data, int uncompressedLength) {
        return data;
    }

    public byte[] ZSTD(byte[] data, int uncompressedLength) {
        return data;
    }
}