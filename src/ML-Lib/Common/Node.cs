namespace ML_Lib.Common;

public class Node
{
    public string Attribute { get; set; } = string.Empty;
    public Dictionary<string, Node> Children { get; set; } = [];
    public string LeafValue { get; set; } = string.Empty;
    public bool IsLeaf { get; set; } = false;
}
