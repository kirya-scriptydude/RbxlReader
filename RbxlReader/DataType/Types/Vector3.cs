namespace RbxlReader.DataTypes;

public class Vector3 {
    public float X, Y, Z;
    public override string ToString() => $"{X}, {Y}, {Z}";

    public Vector3() {}

    public Vector3(float x, float y, float z) {
        X = x;
        Y = y;
        Z = z;
    }
}