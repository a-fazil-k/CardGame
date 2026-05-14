\# Faz 1: Creational Örüntüler - Yapay Zeka Logu



\*\*AI'a Sorulan Prompt:\*\* "Mini oyun motoru projemdeki GameManager sınıfı, kartları (Kaleci, Defans, Forvet) direkt içinde 'new' anahtar kelimesiyle üretiyor. Bu nesne yaratma sürecini esnekleştirmek için Factory Method örüntüsünü nasıl uygulayabilirim? Örnek bir C# kodu yazar mısın?"



\*\*AI'ın Yanıtı (Özet):\*\* AI, `Card` adında soyut bir sınıf oluşturmamı ve her kart tipini bundan türetmemi önerdi. Ardından `CardFactory` adında statik bir sınıf yazarak, string tabanlı (örn: "Forvet") bir parametre ile doğru kart nesnesini döndüren bir `switch` yapısı verdi.



\*\*Benim Uygulamam ve Kararlarım:\*\* AI'ın önerdiği temel yapıyı (CardFactory) kullandım. Ancak AI'ın verdiği kodda eksik olan `BasePower` ve `PlacedPosition` gibi oyuna özgü özellikleri kendim ekleyerek kendi oyun mantığıma entegre ettim. Böylece kodun sadece iskeletini alıp, kendi projemin ihtiyaçlarına göre şekillendirmiş oldum.

