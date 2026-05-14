# Tasarım Örüntüleri Belgelemesi

## Faz 1: Factory Method (Yaratımsal Örüntü)
* **Nerede Kullanıldı:** `CardFactory` sınıfında, oyuncu ve düşman kartlarının (Kaleci, Defans, Forvet) yaratılma sürecinde kullanıldı.
* **Neden Seçildi:** Önceden `GameManager` hangi kartın nasıl üretileceğini bilmek zorundaydı. Factory Method sayesinde üretim sorumluluğu tek bir merkeze alındı.
* **Ne Kazanıldı:** Sisteme ileride "Orta Saha" gibi yeni bir kart tipi eklediğimde, sadece Fabrika'yı (CardFactory) güncellemem yetecek. `GameManager`'ın kodu hiç değişmeyecek (SRP sağlandı).

## Faz 2: Structural (Yapısal) Örüntüler
* **1. Decorator (Dekoratör):** `PositionPenaltyDecorator` sınıfında kullanıldı. Kartların kendi mevkisinde oynamama durumundaki güç düşüşü (%60 ceza) if-else yığınları yerine dinamik bir sarmalayıcı (wrapper) ile çözüldü. Bu sayede OCP (Açık/Kapalı Prensibi) sağlandı.
* **2. Facade (Cephe):** `MatchFacade` sınıfında kullanıldı. `GameManager`'ın içindeki karmaşık kart yaratma, dekoratörle sarmalama ve güç hesaplama işlemleri tek bir arayüzün arkasına gizlendi. İstemci (GameManager) sadece `SetupTeam` ve `CalculateAndShowResult` metotlarını çağırarak detaylardan izole edildi.

**(Not: UML diyagramları Faz 3 sonunda docs/diagrams klasörüne toplu eklenecektir.)**