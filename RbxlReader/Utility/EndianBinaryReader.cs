using System.Buffers.Binary;
using System.Reflection.Metadata.Ecma335;
namespace RbxlReader.Utility;

/// <summary>
/// Better Endian-aware Binary Reader. Thanks LibRbxl for the idea!
/// </summary>
public class EndianBinaryReader {

    private Stream stream;
    /// <summary>
    /// Endianess used.
    /// Little is true (default), while Big is false.
    /// </summary>
    public bool Endianness = true;

    public Stream Stream => stream;

    public EndianBinaryReader(Stream strm, bool IsLittleEndian = true) {
        stream = strm;
        Endianness = IsLittleEndian;
    }

    private void reverseEndian(byte[] buffer) => Array.Reverse(buffer);

     public byte ReadByte() {
        var b = stream.ReadByte();
        if (b == -1) throw new EndOfStreamException();

        return (byte)b;
    }

    public byte[] ReadBytes(int count) {
        byte[] buffer = new byte[count];
        int bytesRead = stream.Read(buffer, 0, count);

        if (count > bytesRead) throw new EndOfStreamException();
        return buffer;
    }

    public long ReadInt64() {
        byte[] buffer = ReadBytes(sizeof(long));
        if (!Endianness) reverseEndian(buffer);
        
        long result = BitConverter.ToInt64(buffer);

        return result;
    }

    public int ReadInt32() {
        byte[] buffer = ReadBytes(sizeof(int));
        if (!Endianness) reverseEndian(buffer);
        
        int result = BitConverter.ToInt32(buffer);

        return result;
    }

    public uint ReadUInt32() {
        byte[] buffer = ReadBytes(sizeof(uint));
        if (!Endianness) reverseEndian(buffer);
        
        uint result = BitConverter.ToUInt32(buffer);

        return result;
    }

    public short ReadInt16() {
        byte[] buffer = ReadBytes(sizeof(short));
        if (!Endianness) reverseEndian(buffer);
        
        short result = BitConverter.ToInt16(buffer);

        return result;
    }

    public ushort ReadUInt16() {
        byte[] buffer = ReadBytes(sizeof(ushort));
        if (!Endianness) reverseEndian(buffer);
        
        ushort result = BitConverter.ToUInt16(buffer);

        return result;
    }

    public double ReadDouble() {
        byte[] buffer = ReadBytes(sizeof(double));
        if (!Endianness) reverseEndian(buffer);
        
        double result = BitConverter.ToDouble(buffer);

        return result;
    }

    public float ReadSingle() {
        byte[] buffer = ReadBytes(sizeof(float));
        if (!Endianness) reverseEndian(buffer);
        
        float result = BitConverter.ToSingle(buffer);

        return result;
    }
}