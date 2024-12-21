namespace RbxlReader.Lab;

public static class RbxlTest {
    public static void FileSize(string[] files) {
        foreach (string filePath in files) {
            var place = new Place(filePath);

            var file = place.Rbxl;
            if (file == null) return;

            var fileSize = new FileInfo(filePath).Length / 1000;

            Console.WriteLine($"""
            ### File {filePath}
            ----------------------
            # Size: {fileSize}KB
            # Chunks: {file.Chunks.Count}

            
            """);
        }
    }
}