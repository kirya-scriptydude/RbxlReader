using RbxlReader.DataTypes;

namespace RbxlReader.Instance;

public class InstanceProperty {
    public PropertyType Type {get;}
    object rawValue;

    public InstanceProperty(PropertyType type, object value) {
        this.Type = type;
        rawValue = value;
    }
}