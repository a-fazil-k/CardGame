### README.md İçeriği

```markdown
# Mini Oyun Motoru - Tasarım Örüntüleri Ödevi
**Seçilen Konu:** C - Mini Oyun Motoru (Oyun nesneleri davranış farklarının örüntülerle çözülmesi).

## Proje Hakkında
Bu proje, bir kart oyununda nesne yaratma karmaşasını, mevki cezalarını ve değişken kazanma kurallarını tasarım örüntüleri kullanarak çözen bir mini motor simülasyonudur.

## Kullanılan Örüntüler
1. **Factory Method (Faz 1):** Kartların (Kaleci, Defans, Forvet) merkezi üretimini sağlar.
2. **Decorator (Faz 2):** Kartlara dinamik olarak mevki cezası ekler.
3. **Facade (Faz 2):** Oyunun başlatılma karmaşasını tek bir arayüz arkasına gizler.
4. **Strategy (Faz 3):** Maç kazanma kurallarını çalışma anında değiştirmeyi sağlar.
5. **Observer (Faz 3):** Maç sonuçlarını otomatik olarak log sistemine raporlar.

## Mimari Diyagram (UML)
```mermaid
classDiagram
    Card <|-- GoalkeeperCard
    Card <|-- StrikerCard
    Card <.. CardFactory : Creates
    Card <|-- CardDecorator
    CardDecorator <|-- PositionPenaltyDecorator
    MatchFacade o-- Card
    MatchFacade o-- IWinningStrategy
    MatchFacade o-- IMatchObserver
    IWinningStrategy <|.. StandardWinStrategy
    IMatchObserver <|.. MatchLogger
