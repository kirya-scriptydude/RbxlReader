namespace RbxlReader.Instance;

/// <summary>
/// Instance is a basic building block of a roblox game. Holds various variables with various data-types.
/// </summary>
public class Instance {
    public string ClassName {get; protected set;}
    
    private Dictionary<string, InstanceProperty> property;

    public Instance(string className, Dictionary<string, InstanceProperty> props) {
        ClassName = className;
        property = props;
    }

    public InstanceProperty? GetProperty(string name) {
        return property.ContainsKey(name) ? property[name] : null;
    }
}