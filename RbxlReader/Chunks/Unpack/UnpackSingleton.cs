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

    public static IUnpackImplementaion Instance() {
        if (unpackInst == null) {
            //Change this line when needed
            unpackInst = new YesUnpack();
        }

        return unpackInst;
    }
}