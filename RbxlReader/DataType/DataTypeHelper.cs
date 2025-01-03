namespace RbxlReader.DataTypes;

public static class DataTypeHelper {
    public static readonly IReadOnlyDictionary<PropertyType, Type> Types = new Dictionary<PropertyType, Type>() {
        // Basics
        {PropertyType.Int, typeof(int)},
        {PropertyType.Float, typeof(float)},
        {PropertyType.Int64, typeof(long)},
        {PropertyType.Double, typeof(double)},
        {PropertyType.String, typeof(string)},
        {PropertyType.Bool, typeof(bool)},

        // Positional
        {PropertyType.Vector2, typeof(Vector2)},
        {PropertyType.Vector3, typeof(Vector3)},
        {PropertyType.Vector3int16, typeof(Vector3int16)},
        {PropertyType.Ray, typeof(Ray)},
        {PropertyType.Rect, typeof(Rect)},
        {PropertyType.UDim, typeof(UDim)},
        {PropertyType.UDim2, typeof(UDim2)},
        {PropertyType.CFrame, typeof(CFrame)},
        {PropertyType.Quaternion, typeof(Quaternion)},

        // Color
        {PropertyType.Color3, typeof(Color3)},
        {PropertyType.Color3uint8, typeof(Color3uint8)},
        {PropertyType.BrickColor, typeof(BrickColor)},

        // Sequence
        {PropertyType.NumberSequence, typeof(NumberSequence)},
        {PropertyType.ColorSequence, typeof(ColorSequence)},
        {PropertyType.NumberRange, typeof(NumberRange)},

        //  random stuff lol
        {PropertyType.OptionalCFrame, typeof(Optional<CFrame>)},
        {PropertyType.SecurityCapabilities, typeof(ulong)},
        {PropertyType.ProtectedString, typeof(ProtectedString)},
        {PropertyType.SharedString, typeof(SharedString)},

        {PropertyType.Axes, typeof(Axes)},
        {PropertyType.Faces, typeof(Faces)}

    };
}