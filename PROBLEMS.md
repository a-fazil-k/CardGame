\# Faz 0: Başlangıç Kodu Analizi



\## Gördüğüm Tasarım Sorunları

1\. \*\*Sınıf Sorumluluğu (God Class):\*\* `GameManager` sınıfı hem kart modelini barındırıyor hem de oyunun tüm hesaplama mantığını üstleniyor.

2\. \*\*Genişlemeye Kapalılık (OCP İhlali):\*\* Yeni bir mevki (örneğin Orta Saha) eklemek istersek mevcut if-else bloklarını değiştirmek zorundayız.

3\. \*\*Tip Güvenliği Yok (Hardcoded Strings):\*\* Mevkiler "Forvet", "Defans" gibi metinlerle kontrol ediliyor. Ufak bir harf hatası sistemi bozar.

4\. \*\*Nesne Yönelimli Olmayan Tasarım:\*\* Kartların kendi güçlerini veya cezalarını hesaplama yeteneği yok; sadece pasif veri tutuyorlar.

5\. \*\*Kod Tekrarı Potansiyeli (DRY İhlali):\*\* Oyuncu için yazılan bu karmaşık hesaplamalar, yapay zeka (düşman) kartları için de birebir kopyalanmak zorunda kalacak.



\## Yapay Zeka (AI) Değerlendirmesi

\*\*AI'a Sorulan Prompt:\*\* "Bu kodda hangi tasarım sorunlarını görüyorsun? Hangi tasarım örüntüleri bu sorunları çözebilir? Her sorun için kısa bir açıklama yaz."



\*\*AI'ın Yanıtı (Özet):\*\* AI da SRP ve OCP ihlallerini tespit etti. Metin kullanımı yerine Enum kullanılması gerektiğini belirtti. Çözüm olarak; nesne yaratımı için \*Factory Method\*, güç hesaplama kuralları için \*Strategy\* ve mevki cezaları için \*Decorator\* örüntülerini önerdi.



\*\*Karşılaştırma:\*\* AI'ın tespitleri benimkilerle tamamen örtüşüyor. Ek olarak, örüntü bazında spesifik çözümler sunarak sonraki fazlar için (Faz 1, 2 ve 3) bana doğrudan yol haritası çıkardı.

