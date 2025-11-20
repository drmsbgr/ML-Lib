namespace ML_Lib.Common;

public class ID3(string targetAttribute)
{
    public Node BuildTree(List<Dictionary<string, string>> data, List<string> attributes)
    {
        var node = new Node();

        // BASE CASE 1: Veri setindeki herkes aynı sınıfa mı ait? (Entropy 0)
        var uniqueTargets = data.Select(r => r[targetAttribute]).Distinct().ToList();
        if (uniqueTargets.Count == 1)
        {
            node.IsLeaf = true;
            node.LeafValue = uniqueTargets[0];
            return node;
        }

        // BASE CASE 2: Kontrol edilecek nitelik kalmadıysa çoğunluğu seç
        if (attributes.Count == 0)
        {
            node.IsLeaf = true;
            node.LeafValue = GetMajorityClass(data);
            return node;
        }

        // En yüksek bilgi kazancına (Information Gain) sahip niteliği bul
        string bestAttribute = "";
        double maxGain = -1;

        foreach (var attr in attributes)
        {
            double gain = CalculateGain(data, attr);
            if (gain > maxGain)
            {
                maxGain = gain;
                bestAttribute = attr;
            }
        }

        node.Attribute = bestAttribute;
        var remainingAttributes = attributes.Where(a => a != bestAttribute).ToList();
        var bestAttrValues = data.Select(r => r[bestAttribute]).Distinct().ToList();

        // Seçilen niteliğin her değeri için bir dal oluştur
        foreach (var value in bestAttrValues)
        {
            var subset = data.Where(r => r[bestAttribute] == value).ToList();

            if (subset.Count == 0)
            {
                // Eğer alt küme boşsa, mevcut verideki çoğunluğu yaprak yap
                var leaf = new Node { IsLeaf = true, LeafValue = GetMajorityClass(data) };
                node.Children.Add(value, leaf);
            }
            else
            {
                node.Children.Add(value, BuildTree(subset, remainingAttributes));
            }
        }

        return node;
    }

    private double CalculateEntropy(List<Dictionary<string, string>> data)
    {
        if (data.Count == 0) return 0;

        var classCounts = data
            .GroupBy(row => row[targetAttribute])
            .Select(g => g.Count())
            .ToList();

        double entropy = 0;
        double total = data.Count;

        foreach (var count in classCounts)
        {
            double probability = count / total;
            entropy -= probability * Math.Log(probability, 2);
        }

        return entropy;
    }

    private double CalculateGain(List<Dictionary<string, string>> data, string attribute)
    {
        double originalEntropy = CalculateEntropy(data);
        double weightedEntropy = 0;
        double total = data.Count;

        // Niteliğin alabileceği her değer için (örn: Güneşli, Yağmurlu)
        var distinctValues = data.Select(row => row[attribute]).Distinct();

        foreach (var value in distinctValues)
        {
            // O değere sahip alt kümeyi oluştur
            var subset = data.Where(row => row[attribute] == value).ToList();

            double probability = subset.Count / total;
            weightedEntropy += probability * CalculateEntropy(subset);
        }

        return originalEntropy - weightedEntropy;
    }

    private string GetMajorityClass(List<Dictionary<string, string>> data)
    {
        return data.GroupBy(r => r[targetAttribute])
                   .OrderByDescending(g => g.Count())
                   .First().Key;
    }
}