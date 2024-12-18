using LZ4;

namespace RbxlReader.Chunks.Unpacking;

/// <summary>
/// TODO
/// </summary>
internal class YesUnpack : IUnpackImplementaion {
    public byte[] LZ4(byte[] data, int uncompressedLength) {
        byte[] target = new byte[uncompressedLength];

        int written = LZ4Codec.Decode(data, 0, data.Length, target, 0, uncompressedLength, true);
        return target;
    }

    public byte[] ZSTD(byte[] data) {
        return data;
    }
}