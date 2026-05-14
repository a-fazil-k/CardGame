# Faz 0: Başlangıç Kodu Analizi ve Sorun Tespiti

## Tespit Edilen Tasarım Sorunları

1. **Sorumluluk Karmaşası (God Class Antipattern):** GameManager sınıfı hem kart modellerini barındırıyor hem de oyunun tüm hesaplama ve akış mantığını tek başına üstleniyor. Bu durum sınıfın aşırı büyümesine ve bakımının zorlaşmasına neden olmaktadır.
2. **Genişlemeye Kapalılık (Açık/Kapalı Prensibi İhlali):** Yeni bir kart tipi veya mevki (örneğin Orta Saha) eklemek istediğimizde, mevcut kodun içine girip if-else bloklarını manuel olarak değiştirmek zorundayız. Bu durum OCP prensibini ihlal etmektedir.
3. **Tip Güvenliği Eksikliği (Hardcoded Strings):** Mevkiler "Forvet", "Defans" gibi metin (string) değerlerle kontrol ediliyor. Küçük bir harf hatası sistemin hatalı çalışmasına yol açabilir; bu da sistemin kırılgan olduğunu gösterir.
4. **Zayıf Nesne Yönelimli Tasarım:** Kart nesnelerinin kendi güçlerini veya cezalarını hesaplama yeteneği yok; sadece pasif veri tutuyorlar. Hesaplama mantığının dışarıdan yönetilmesi nesne yönelimli felsefeye aykırıdır.
5. **Kod Tekrarı Potansiyeli (DRY İhlali):** Oyuncu için yazılan karmaşık hesaplama mantığı, yapay zeka (düşman) kartları eklendiğinde büyük ihtimalle kopyala-yapıştır yöntemiyle çoğaltılacaktır. Bu da kodun sürdürülebilirliğini azaltır.

## Yapay Zeka (AI) İle Karşılaştırmalı Değerlendirme

**Kullanılan AI Promptu:** "Bu kodda hangi tasarım sorunlarını görüyorsun? Hangi tasarım örüntüleri bu sorunları çözebilir? Her sorun için kısa bir açıklama yaz."

**AI Yanıt Özeti:** Yapay zeka, analizinde özellikle SRP (Tek Sorumluluk) ve OCP (Açık/Kapalı) ihlallerini tespit etti. Metin tabanlı kontroller yerine Enum kullanımını önerdi. Çözüm yolu olarak; nesne yaratımı için Factory Method, güç hesaplama kuralları için Strategy ve mevki cezaları için Decorator örüntülerini sundu.

**Kişisel Karşılaştırma ve Analiz:** Yapay zekanın teknik tespitleri benim belirlediğim sorunlarla tamamen örtüşüyor. AI, özellikle teorik prensipler (SRP, OCP) üzerinden eksikleri daha net tanımladı. Ayrıca sunduğu örüntü önerileri, sonraki fazlarda (Faz 1, 2 ve 3) uygulayacağım mimari değişiklikler için bana doğrudan bir yol haritası çıkarmış oldu.
