# Katkıda Bulunma Rehberi

ML-Lib projesine katkıda bulunmak istediğiniz için teşekkürler! Her türlü katkı, projenin gelişimi için büyük önem taşımaktadır.

## Nasıl Katkıda Bulunabilirim?

### Hata Bildirimi

Bir hata ile karşılaşırsanız, lütfen GitHub üzerinden bir "Issue" açarak bize bildirin. Hata raporunuzda aşağıdaki bilgileri eklemeye çalışın:

- Hatanın oluştuğu ortam (örn: .NET sürümü, işletim sistemi).
- Hatayı yeniden oluşturmak için gereken adımlar.
- Beklenen davranışın ne olduğu.
- Gerçekleşen davranışın ne olduğu (hata mesajları ve ekran görüntüleri ile birlikte).

### Özellik Talepleri

Yeni bir özellik veya mevcut bir özellikte bir geliştirme önermek isterseniz, yine bir "Issue" açarak talebinizi detaylı bir şekilde açıklayabilirsiniz. Neden bu özelliğe ihtiyaç duyduğunuzu ve nasıl bir çözüm hayal ettiğinizi belirtmeniz, talebinizin daha iyi anlaşılmasına yardımcı olacaktır.

### Kod Katkısı (Pull Request)

Kod katkısı yapmak için lütfen aşağıdaki adımları izleyin:

1.  **Fork Edin:** Projeyi kendi GitHub hesabınıza çatallayın (fork).
2.  **Branch Oluşturun:** Yeni özelliğiniz veya hata düzeltmeniz için açıklayıcı bir isme sahip yeni bir dal (branch) oluşturun.
    ```bash
    git checkout -b ozellik/yeni-harika-ozellik
    ```
3.  **Değişikliklerinizi Yapın:** Kodunuzu yazın ve gerekli testleri eklediğinizden emin olun. Kod stilinin projenin geri kalanıyla tutarlı olmasına özen gösterin.
4.  **Commit Edin:** Yaptığınız değişiklikleri anlamlı commit mesajları ile kaydedin.
    ```bash
    git commit -m "Özellik: Yeni harika özellik eklendi"
    ```
5.  **Push Edin:** Oluşturduğunuz dalı kendi forkladığınız reponuza gönderin.
    ```bash
    git push origin ozellik/yeni-harika-ozellik
    ```
6.  **Pull Request Açın:** GitHub üzerinden orijinal `ML-Lib` reposuna bir Pull Request (PR) açın. PR açıklamasında yaptığınız değişiklikleri net bir şekilde özetleyin.

## Kodlama Standartları

- Projenin genel kodlama stiline uymaya özen gösterin.
- Yeni eklenen tüm public metotlar ve sınıflar için XML dokümantasyon yorumları ekleyin.
- Yaptığınız değişiklikler için (mümkünse) birim testleri (unit tests) yazın. `ML-Lib.Tests` projesindeki mevcut testleri inceleyebilirsiniz.

Katkılarınız için şimdiden teşekkürler!
