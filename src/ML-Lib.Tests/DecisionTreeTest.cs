using ML_Lib.Algorithms.Classification;

namespace ML_Lib.Tests;

public class DecisionTreeTest
{
    [Fact]
    public void DecisionTreeTrainer_CanTrainSimpleDataset()
    {
        //Given
        var trainingData = new List<Dictionary<string, string>>()
        {
            new() {{"Outlook","Sunny"},{"Temperature","Hot"},{"Humidity","High"},{"Wind","Weak"},{"PlayTennis","No"}},
            new() {{"Outlook","Sunny"},{"Temperature","Hot"},{"Humidity","High"},{"Wind","Strong"},{"PlayTennis","No"}},
        };

        var targetAttribute = "PlayTennis";

        // When
        var trainer = new DecisionTreeTrainer(targetAttribute);
        var model = trainer.Train(trainingData);

        // Assert
        Assert.NotNull(model);
        Assert.NotNull(model.Root);
        Assert.Equal("No", model.Root.LeafValue);
    }

    [Fact]
    public void DecisionTree_PredictTest()
    {
        // Given
        var trainingData = new List<Dictionary<string, string>>
        {
            new() { {"Hava", "Güneşli"}, {"Nem", "Yüksek"}, {"Oyna", "Hayır"} },
            new() { {"Hava", "Güneşli"}, {"Nem", "Normal"}, {"Oyna", "Evet"} },
            new() { {"Hava", "Bulutlu"}, {"Nem", "Yüksek"}, {"Oyna", "Evet"} },
            new() { {"Hava", "Yağmurlu"}, {"Nem", "Yüksek"}, {"Oyna", "Hayır"} },
            new() { {"Hava", "Yağmurlu"}, {"Nem", "Normal"}, {"Oyna", "Evet"} }
        };

        var targetAttribute = "Oyna";

        // When
        var trainer = new DecisionTreeTrainer(targetAttribute);
        var model = trainer.Train(trainingData);
        var predict = model.Predict(new() { { "Hava", "Güneşli" }, { "Nem", "Yüksek" } });

        // Then
        Assert.Equal("Hayır", predict);
    }
}
