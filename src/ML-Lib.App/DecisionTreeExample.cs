using ML_Lib.Algorithms.Classification;

namespace ML_Lib.App;

public static class DecisionTreeExample
{
    public static void Exec()
    {
        var trainingData = new List<Dictionary<string, string>>
        {
            new() { {"Hava", "Güneşli"}, {"Nem", "Yüksek"}, {"Oyna", "Hayır"} },
            new() { {"Hava", "Güneşli"}, {"Nem", "Normal"}, {"Oyna", "Evet"} },
            new() { {"Hava", "Bulutlu"}, {"Nem", "Yüksek"}, {"Oyna", "Evet"} },
            new() { {"Hava", "Yağmurlu"}, {"Nem", "Yüksek"}, {"Oyna", "Hayır"} },
            new() { {"Hava", "Yağmurlu"}, {"Nem", "Normal"}, {"Oyna", "Evet"} }
        };

        var targetAttribute = "Oyna";
        var trainer = new DecisionTreeTrainer(targetAttribute);
        var model = trainer.Train(trainingData);

        model.PrintTree();

        var predict = model.Predict(new() { { "Hava", "Bulutlu" }, { "Nem", "Normal" } });
        Console.WriteLine($"Tahmin: {predict}");
    }
}