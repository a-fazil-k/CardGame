\# Faz 3: Behavioral Örüntüler - Yapay Zeka Logu (Pair Programming)



\*\*AI ile Pair Programming Süreci (30 Dakika):\*\*

Oyunun kazanma kurallarını (Standart vs. Zorlu mod) if-else kullanmadan dinamik olarak nasıl değiştirebileceğimi AI ile tartıştım.



\*\*AI'ın Yönlendirmesi:\*\* State ve Strategy örüntülerini karşılaştırdık. AI, kuralların dışarıdan enjekte edilebilmesi ve sadece bir algoritma değişikliği olması sebebiyle Strategy örüntüsünün daha uygun olduğunu söyledi. `IWinningStrategy` arayüzü yazıp farklı kuralları bundan türetmemi önerdi.



\*\*Benim Kararlarım:\*\* AI'ın önerdiği Strategy yapısını kurdum. Oyuncunun oyun sırasında mod değiştirebilmesi için Facade sınıfımın içine `SetWinningStrategy` metodunu ekledim. Böylece oyun motorunu durdurmadan kazanma kuralını anında değiştirebiliyoruz.

