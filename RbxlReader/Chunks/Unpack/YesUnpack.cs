using LZ4;
using ZstdSharp;

namespace RbxlReader.Chunks.Unpacking;

/// <summary>
/// TODO
/// </summary>
internal class YesUnpack : IUnpackImplementaion {
    public byte[] LZ4(byte[] data, int uncompressedLength) {
        byte[] output = new byte[uncompressedLength];

        LZ4Codec.Decode(data, 0, data.Length, output, 0, uncompressedLength, true);
        return output;
    }

    public byte[] ZSTD(byte[] data, int uncompressedLength) {
        byte[] output = new byte[uncompressedLength];
        var decompressor = new Decompressor();

        decompressor.Unwrap(data, 0, data.Length, output, 0, uncompressedLength);
        return data;
    }
}