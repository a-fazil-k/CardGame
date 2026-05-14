# Faz 1: Creational Örüntüler - Yapay Zeka Logu

**AI'a Sorulan Prompt:** "Mini oyun motoru projemdeki GameManager sınıfı, kartları (Kaleci, Defans, Forvet) direkt içinde 'new' anahtar kelimesiyle üretiyor. Bu nesne yaratma sürecini esnekleştirmek için Factory Method örüntüsünü nasıl uygulayabilirim? Örnek bir C# kodu yazar mısın?"

**AI'ın Yanıtı (Özet):** AI, Card adında soyut bir sınıf oluşturmamı ve her kart tipini bundan türetmemi önerdi. Ardından CardFactory adında bir sınıf yazarak, string tabanlı (örn: "Forvet") bir parametre ile doğru kart nesnesini döndüren bir switch yapısı verdi.

**Benim Uygulamam ve Kararlarım:** AI'ın önerdiği temel Factory Method yapısını projeme başarıyla entegre ettim. Ancak AI, seçim mekanizması için yine riskli olan string (metin) yapısını önermişti. Faz 0'da tespit ettiğim "Hardcoded Strings" sorununu çözmek adına, AI'ın bu önerisini reddederek seçimi **Enum** yapısı üzerinden gerçekleştirdim. Ayrıca AI'ın kodunda eksik olan BasePower ve PlacedPosition gibi oyuna özgü özellikleri kendim ekleyerek sistemi oyun mantığıma tam uyumlu hale getirdim.
