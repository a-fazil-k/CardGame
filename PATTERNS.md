# Tasarım Örüntüleri Belgelemesi

## Faz 1: Factory Method (Yaratımsal Örüntü)
* **Nerede Kullanıldı:** `CardFactory` sınıfı.
* **Neden Seçildi:** `GameManager` hangi kartın nasıl üretileceğini bilmek zorundaydı. Üretim sorumluluğu Fabrika'ya alındı.

## Faz 2: Structural (Yapısal) Örüntüler
* **1. Decorator:** `PositionPenaltyDecorator` sınıfı. Kendi mevkisinde oynamama durumundaki güç düşüşü (%60 ceza) dinamik bir sarmalayıcı ile çözüldü (OCP sağlandı).
* **2. Facade:** `MatchFacade` sınıfı. İstemci (GameManager) karmaşık hesaplamalardan izole edildi.

## Faz 3: Behavioral (Davranışsal) Örüntüler
* **1. Strategy (Strateji):** `IWinningStrategy` arayüzü ve `StandardWinStrategy`, `HardcoreWinStrategy` sınıfları.
* **Neden Seçildi:** Oyunun "maç kazanma kurallarını" koda gömmek yerine dışarıdan enjekte etmek istedik.
* **Ne Kazanıldı:** Yeni bir oyun modu (örneğin "Altın Gol") eklendiğinde mevcut kodlara hiç dokunmadan sadece yeni bir strateji sınıfı yazmamız yetecek.