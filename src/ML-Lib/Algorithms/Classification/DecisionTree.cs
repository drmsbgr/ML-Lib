using ML_Lib.Common;
using ML_Lib.Interfaces;

namespace ML_Lib.Algorithms.Classification;

public class DecisionTree(Node root) : IPredictable<Dictionary<string, string>, string>
{
    public Node Root { get; private set; } = root;

    public string Predict(Dictionary<string, string> entry)
    {
        var current = Root;

        while (!current.IsLeaf)
        {
            var value = entry[current.Attribute];
            current = current.Children[value];
        }

        return current.LeafValue;
    }

    public void PrintTree()
    {
        static void _PrintTree(Node node, string indent)
        {
            if (node.IsLeaf)
            {
                Console.WriteLine($"{indent}-> Karar: {node.LeafValue}");
                return;
            }

            Console.WriteLine($"{indent}[{node.Attribute}]");
            foreach (var child in node.Children)
            {
                Console.WriteLine($"{indent}  -- {child.Key} -->");
                _PrintTree(child.Value, indent + "    ");
            }
        }

        _PrintTree(Root, "");
    }
}
