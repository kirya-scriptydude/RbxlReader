using RbxlReader.Chunks;
using RbxlReader.Instances;

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

    /// <summary>
    /// Parse the data left in PROP chunk. Need to read PROP header first (Class, PropertyName, etc.) before calling this method.
    /// </summary>
    public static InstanceProperty[] ParsePropertiesInChunk(RbxlBinaryReader reader, PropertyType type, int instCount) {

        InstanceProperty[] props = new InstanceProperty[instCount];
        Type? typeClass = Types[type];

        if (typeClass == null)
            throw new ArgumentNullException($"Type {type} isn't implemented.");

        //  shorthand functions
        var readInts = new Func<int[]>(() => reader.ReadInterleaved(instCount, reader.RotateInt32));
        var readFloats = new Func<float[]>(() => reader.ReadInterleaved(instCount, reader.RotateFloat));

        switch(type) {

            case PropertyType.String:
                readProps(props, instCount, i => {

                    string value = reader.ReadString();
                    
                    byte[] buffer = reader.GetLastStringBuffer();
                    props[i].RawBuffer = buffer;

                    return value;

                });
                break;
            
            case PropertyType.Bool: {
                readProps(props, instCount, i => reader.ReadBoolean());
                break;
            }
            
            case PropertyType.Int: {
                int[] ints = readInts();
                readProps(props, instCount, i => ints[i]);
                break;
            }
            
            case PropertyType.Float: {
                float[] floats = readFloats();
                readProps(props, instCount, i => floats[i]);
                break;
            }
            
            case PropertyType.Double: {
                readProps(props, instCount, i => reader.ReadDouble());
                break;
            }

            case PropertyType.UDim: {
                float[] scales = readFloats();
                int[] offsets = readInts();

                readProps(props, instCount,i => {
                    float scale = scales[i];
                    int offset = offsets[i];
                    return new UDim(scale, offset);
                });

                break;
            }

            case PropertyType.UDim2: {
                float[] scalesX = readFloats();
                float[] scalesY = readFloats();

                int[] offsetsX = readInts();
                int[] offsetsY = readInts();

                readProps(props, instCount, i => {
                    float scaleX = scalesX[i];
                    float scaleY = scalesY[i];

                    int offsetX = offsetsX[i];
                    int offsetY = offsetsY[i];

                    return new UDim2(
                        new UDim(scaleX, offsetX),
                        new UDim(scaleY, offsetY)
                    );
                });
                
                break;
            }

        }

        return props;
    }

    private static void readProps(InstanceProperty[] props, int instCount, Func<int, object> read) {
        for (int i = 0; i < instCount; i++) {
            var prop = props[i];

            if (prop == null)
                continue;
            
            prop.Value = read(i);
        }
    }
}