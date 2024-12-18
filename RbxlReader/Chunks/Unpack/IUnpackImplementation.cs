namespace RbxlReader.Chunks.Unpacking;

public interface IUnpackImplementaion {
    /// <summary>
    /// Uncompresses LZ4 binary data.
    /// </summary>
    /// <param name="data">LZ4 compressed data</param>
    /// <returns>Uncompressed data</returns>
    public byte[] LZ4(byte[] data, int uncompressedLength);
    
    /// <summary>
    /// Uncompresses ZSTD binary data.
    /// </summary>
    /// <param name="data">ZSTD compressed data</param>
    /// <returns>Uncompressed data</returns>
    public byte[] ZSTD(byte[] data);
}