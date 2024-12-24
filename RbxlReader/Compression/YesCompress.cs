using K4os.Compression.LZ4;
using ZstdSharp;

namespace RbxlReader.Compression;

public class YesCompress : ICompressionImplementation {
    public byte[] DecodeLZ4(byte[] src, int targetLen) {
        byte[] output = new byte[targetLen];

        LZ4Codec.Decode(src, 0, src.Length, output, 0, output.Length);

        return output;
    }
    public byte[] DecodeZSTD(byte[] src, int targetLen) {
        byte[] output = new byte[targetLen];
        var decompressor = new Decompressor();
        
        decompressor.Unwrap(src, 0, src.Length, output, 0, output.Length);

        return output;
    }
}