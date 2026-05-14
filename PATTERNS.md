# Tasarım Örüntüleri Belgelemesi

## Faz 1: Yaratımsal (Creational) Örüntüler

* **Factory Method:** `CardFactory` sınıfı.
* **Neden Seçildi:** `GameManager` sınıfının kartların somut sınıflarına olan bağımlılığını azaltmak ve nesne üretimini tek bir merkezden yönetmek için seçildi. Böylece yeni bir kart tipi eklendiğinde sadece fabrikayı güncellemek yeterli oluyor.

## Faz 2: Yapısal (Structural) Örüntüler

* **1. Decorator:** `PositionPenaltyDecorator` sınıfı.
* **Neden Seçildi:** Kartlara çalışma anında dinamik olarak mevki cezası ekleyebilmek için tercih edildi. Mevcut kart sınıflarının kodunu bozmadan (OCP) yeni özellikler eklememizi sağladı.
* **2. Facade:** `MatchFacade` sınıfı.
* **Neden Seçildi:** Oyunun başlatılması, kartların oluşturulması ve kuralların ayarlanması gibi karmaşık alt sistem işlemlerini tek bir basit arayüz arkasında toplamak için kullanıldı.

## Faz 3: Davranışsal (Behavioral) Örüntüler

* **1. Strategy (Strateji):** `IWinningStrategy` arayüzü ve ilgili strateji sınıfları.
* **Neden Seçildi:** Oyunun kazanma mantığını (Standart vs. Hardcore) sınıftan ayırarak çalışma anında değiştirilebilir hale getirmek için uygulandı. Yeni bir oyun modu eklendiğinde mevcut kodları değiştirmeden sadece yeni bir sınıf yazmamız yetiyor.
* **2. Observer (Gözlemci):** `IMatchObserver` arayüzü ve `MatchLogger` sınıfı.
* **Neden Seçildi:** Maç sonuçlarını takip eden sistemleri (loglama, bildirimler vb.) oyun motorundan ayırmak için kullanıldı. Bu sayede yeni bir raporlama sistemi eklendiğinde motor koduna dokunmamıza gerek kalmıyor (Loose Coupling).
