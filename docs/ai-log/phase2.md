# Faz 2: Structural (Yapısal) Örüntüler - Yapay Zeka Logu

**AI'a Sorulan Prompt:** "Kart oyunumda oyuncu kendi mevkisi dışında oynadığında gücünü düşüren bir sistem ve oyunun başlatılma karmaşasını çözen bir yapı kurmak istiyorum. Structural örüntülerden Adapter mı yoksa Facade mı kullanmalıyım? Mevki cezası için ne önerirsin?"

**AI'ın Yanıtı (Özet):** AI, oyun motorunu basitleştirmek ve alt sistemleri gizlemek için Adapter yerine **Facade** kullanmamın çok daha uygun olacağını belirtti. Mevki cezaları gibi nesne özelliklerini dinamik olarak değiştirmek içinse **Decorator** örüntüsünü önerdi.

**Benim Uygulamam ve Kararlarım:** AI'ın yönlendirmesiyle `MatchFacade` sınıfını kurarak `GameManager` üzerindeki yükü azalttım; bu sayede motorun başlatılma sürecini tek bir metod üzerinden yönetebiliyorum. Mevki cezası için `PositionPenaltyDecorator` sınıfını yazdım. 

**Kritik Karar:** AI başlangıçta ceza oranını dışarıdan parametre olarak alabilen çok daha esnek bir yapı önerdi. Ancak ödevin kapsamını aşmamak ve mevcut dengeyi korumak adına, ceza oranını `%60 (0.6f)` olarak dekoratör içinde sabit tutmaya karar verdim. Bu durum, AI'ın "her şeyi jenerik yapma" eğilimine karşı projenin basitliğini korumak adına verdiğim bir karardır.
