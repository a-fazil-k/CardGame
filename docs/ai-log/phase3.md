# Faz 3: Davranışsal (Behavioral) Örüntüler - Yapay Zeka Logu (Pair Programming)

**AI ile Pair Programming Süreci (40 Dakika):**
Bu fazda, oyunun kazanma kurallarını (Standart vs. Hardcore) dinamik olarak nasıl değiştirebileceğimi ve maç sonuçlarını diğer sistemlere nasıl haber verebileceğimi AI ile tartıştım.

**AI'ın Yönlendirmesi:**
Kazanma kuralları için State ve Strategy örüntülerini karşılaştırdık. AI, kuralların dışarıdan enjekte edilebilmesi ve sadece bir algoritma değişikliği olması nedeniyle **Strategy** örüntüsünün daha uygun olduğunu belirtti. Maç sonuçlarının raporlanması için ise başlangıçta basit C# event yapılarını önerdi.

**Benim Kararlarım:**
AI'ın Strategy önerisini kabul ettim ve `SetWinningStrategy` metodunu `MatchFacade` sınıfı içine ekleyerek oyun motorunu durdurmadan kural değişikliği yapabilmeyi sağladım. Ancak raporlama kısmında, AI'ın "event" önerisi yerine ödevin amacına (Tasarım Örüntüleri) daha uygun olan ve daha genişletilebilir bir yapı sunan **Observer** örüntüsünü (interface tabanlı) kullanmaya karar verdim.

**Kritik Değerlendirme:**
* **AI olmadan bu faz ne kadar sürerdi?** Strategy ve Observer örüntülerinin entegrasyonu ve CI/CD pipeline süreçlerindeki derleme hatalarının manuel çözümü tahminen 4-5 saatimi alırdı. AI desteğiyle bu süreci yaklaşık 40 dakikada tamamladım.
* **AI sizi nerede yanılttı?** AI başlangıçta Observer yerine daha basit olan event/delegate yapısını kullanmamı önerdi. Ancak ben "Behavioral Pattern" mantığını tam uygulamak ve akademik gereksinimleri karşılamak için klasik Observer yapısında ısrar ettim. Ayrıca CI yapılandırma dosyasında AI bazen güncel olmayan versiyonlar önerdi, bunları dokümantasyona bakarak manuel düzelttim.
