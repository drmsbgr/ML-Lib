# ML-Lib: C# ile Veri Madenciliği Algoritmaları

Bu proje, "Veri Madenciliği ve Bilgi Keşfi" dersi kapsamında öğrenilen temel makine öğrenmesi ve veri madenciliği algoritmalarının C# dilinde bir kütüphane olarak geliştirilmesi amacıyla oluşturulmuştur. Projenin temel hedefi, bu algoritmaların pratik uygulamalarını C# ekosistemi içerisinde kolayca erişilebilir ve kullanılabilir hale getirmektir.

## 🚀 Amaç ve Kapsam

Bu kütüphane, eğitim ve araştırma amaçlı olarak aşağıdaki hedefleri benimsemektedir:

- **Eğitimsel Kaynak:** Veri madenciliği algoritmalarının C# dilinde nasıl implemente edildiğini gösteren bir kaynak oluşturmak.
- **Pratik Uygulama:** .NET platformunda geliştirme yapanlar için temel makine öğrenmesi modellerini kolayca projelerine entegre etme imkanı sunmak.
- **Genişletilebilirlik:** Yeni algoritmaların kolayca eklenebileceği modüler bir yapı sağlamak.

## 🛠️ İçerdiği Algoritmalar

Kütüphane içerisinde aşağıdaki algoritmaların implementasyonları bulunmaktadır (veya planlanmaktadır):

### Sınıflandırma (Classification)

- k-En Yakın Komşu (k-Nearest Neighbors - k-NN)
- \*Karar Ağaçları (Decision Trees - ID3, C4.5)
- \*Naive Bayes

### Kümeleme (Clustering)

- k-Means
- \*DBSCAN

### Birliktelik Kuralı Madenciliği (Association Rule Mining)

- Apriori

## 📦 Kurulum

Bu kütüphaneyi projenize dahil etmek için (örneğin, NuGet paketi olarak yayınlandığında):

```powershell
Install-Package ML-Lib
```

Veya projeyi klonlayıp doğrudan projenize referans olarak ekleyebilirsiniz:

```bash
git clone https://github.com/drmsbgr/ML-Lib.git
```

## 💻 Kullanım Örneği

Aşağıda `k-NN` algoritmasının basit bir kullanım örneği gösterilmiştir:

```csharp
//veriyi hazırlıyoruz
var data = MatrixFactory
    .Create(10, 2)
    .AddRow(2, 1)
    .AddRow(3, 3)
    .AddRow(4, 4)
    .AddRow(5, 5)
    .AddRow(6, 6)
    .AddRow(1, 7)
    .AddRow(2, 2)
    .AddRow(3, 2)
    .AddRow(4, 1)
    .AddRow(3, 1);

//algoritmayı tanımlıyoruz
var kmeans = new KMeans(new(2));
//çalıştırıyoruz
var clusterIds = VectorFactory.Create(kmeans.Cluster(data)).Label("ClusterIds");
Console.WriteLine(clusterIds);
```

## 🙌 Katkıda Bulunma

Bu projeye katkıda bulunmak isterseniz, lütfen `CONTRIBUTING.md` dosyasını inceleyin. Hata bildirimleri, yeni özellik istekleri ve pull request'ler her zaman beklerim!

## 📜 Lisans

Bu proje MIT Lisansı altında lisanslanmıştır. Detaylar için `LICENSE` dosyasına bakınız.
