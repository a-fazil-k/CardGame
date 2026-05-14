\# Faz 2: Structural Örüntüler - Yapay Zeka Logu



\*\*AI'a Sorulan Prompt:\*\* "Kart oyunumda oyuncu kendi mevkisi dışında oynadığında gücünü düşüren bir sistem ve oyunun başlatılma karmaşasını çözen bir yapı kurmak istiyorum. Structural örüntülerden Adapter mı yoksa Facade mı kullanmalıyım? Mevki cezası için ne önerirsin?"



\*\*AI'ın Yanıtı (Özet):\*\* AI, oyun motorunu basitleştirmek ve alt sistemleri gizlemek için Adapter yerine \*Facade\* kullanmamın çok daha uygun olacağını belirtti (Çünkü Adapter, birbirine uymayan iki farklı arayüzü konuşturmak içindir). Mevki cezaları içinse özellikleri dinamik olarak değiştirebilen \*Decorator\* örüntüsünü önerdi.



\*\*Benim Uygulamam ve Kararlarım:\*\* AI'ın yönlendirmesiyle `MatchFacade` sınıfını kurarak GameManager'ı rahatlattım. Mevki cezası için `PositionPenaltyDecorator` yazdım. Başlangıçta dekoratör içindeki ceza oranını dışarıdan parametre olarak almayı düşündüm ancak ödevin kapsamını aşmamak ve basit tutmak adına %60 ceza oranını (0.6f) şimdilik içeride sabit tutma kararı aldım.

