namespace RbxlReader.Chunks.Unpacking;

/// <summary>
/// Singleton that handles decompressing .rbxl binary data.
/// Due to s&box not allowing custom DLL's or nuget packages, there is going to be two versions - one with decompressing libraries and one without.
/// No plug&play for s&box i guess
/// 
/// All of this made to make deleting unsupported code less painful when inevitably moving to s&box.
/// </summary>
public static class Unpack {
    static IUnpackImplementaion? unpackInst;

    public static readonly byte[] ZSTD_MAGIC_NUMBER = [20, 181, 47, 253];

    public static IUnpackImplementaion Instance() {
        if (unpackInst == null) {
            //Change this line when needed
            unpackInst = new YesUnpack();
        }

        return unpackInst;
    }

    public static byte[] TryDecode(byte[] data, int uncompressedLength) {
        var instance = Instance();

        //possible magicnumber thats used by zstd
        byte[] possibleMagicNumber = [data[0], data[1], data[2], data[3]];
        bool isZstd = ZSTD_MAGIC_NUMBER.SequenceEqual(possibleMagicNumber);

        return isZstd ? instance.ZSTD(data, uncompressedLength) : instance.LZ4(data, uncompressedLength);
    }

    public static byte[] GetUncompressedBytes(Stream stream, ChunkHeader header) {
        byte[] data;
        BinaryReader read = new BinaryReader(stream);
        
        if (header.IsCompressed) {
            data = TryDecode(read.ReadBytes((int)header.CompressedLength), (int)header.UncompressedLength);
        } else {
            data = read.ReadBytes((int)header.UncompressedLength);
        }

        return data;
    }
}