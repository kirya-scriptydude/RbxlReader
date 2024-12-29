using RbxlReader.DataTypes;

namespace RbxlReader.Instances;

/// <summary>
/// Instance is a basic building block of a roblox game. Holds various variables with various data-types.
/// </summary>
public class Instance {
    public PlaceBinary? Rbxl {get; set;}

    public string ClassName {get; protected set;}
    
    private Dictionary<string, InstanceProperty> property;


    public Instance Parent {get {
        if (parentInst == null)
            throw new NullReferenceException("Parent not found");
        
        return parentInst;
    }}

    public Instance? parentInst;
    private List<Instance> children = new();

    public Instance(string className, Dictionary<string, InstanceProperty> props) {
        ClassName = className;
        property = props;
    }

    public Instance(string className) {
        ClassName = className;
        property = new();
    }

    public InstanceProperty? GetProperty(string name) {
        return property.ContainsKey(name) ? property[name] : null;
    }

    public void AddProperty(string name, PropertyType type, object value) {
        property.Add(name,
            new InstanceProperty(type, value)
        );
    }
}