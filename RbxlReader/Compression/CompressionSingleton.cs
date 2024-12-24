namespace RbxlReader.Compression;

public static class CompressionSingleton {
    private static ICompressionImplementation? instance;

    public static ICompressionImplementation GetInstance() {
        if (instance == null)
            instance = new YesCompress();
        
        return instance;
    }
}