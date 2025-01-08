namespace RbxlReader.DataTypes;

public struct RbxlEulerAngles {
    public float Yaw;
    public float Pitch;
    public float Roll;
}

public class CFrame {
    private readonly float m14, m24, m34;
    private readonly float m11 = 1, m12, m13;
    private readonly float m21, m22 = 1, m23;
    private readonly float m31, m32, m33 = 1;

    private const float m41 = 0, m42 = 0, m43 = 0, m44 = 1;
    public float X => m14;
    public float Y => m24;
    public float Z => m34;

    public Vector3 Position => new Vector3(X, Y, Z);

    public CFrame() {
        m14 = 0;
        m24 = 0;
        m34 = 0;
    }
    public CFrame(Vector3 pos) {
        m14 = pos.X;
        m24 = pos.Y;
        m34 = pos.Z;
    }

    public RbxlEulerAngles ToEulerAngles() => new RbxlEulerAngles {
        Yaw   = (float)Math.Asin(m13),
        Pitch = (float)Math.Atan2(-m23, m33),
        Roll  = (float)Math.Atan2(-m12, m11),
    };
}