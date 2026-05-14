\# Tasarım Örüntüleri Belgelemesi



\## Faz 1: Factory Method (Yaratımsal Örüntü)

\* \*\*Nerede Kullanıldı:\*\* `CardFactory` sınıfında, oyuncu ve düşman kartlarının (Kaleci, Defans, Forvet) yaratılma sürecinde kullanıldı.

\* \*\*Neden Seçildi:\*\* Önceden `GameManager` hangi kartın nasıl üretileceğini bilmek zorundaydı. Factory Method sayesinde üretim sorumluluğu tek bir merkeze alındı.

\* \*\*Ne Kazanıldı:\*\* Sisteme ileride "Orta Saha" gibi yeni bir kart tipi eklediğimde, sadece Fabrika'yı (CardFactory) güncellemem yetecek. `GameManager`'ın kodu hiç değişmeyecek (SRP sağlandı).



\*\*(Not: UML diyagramları Faz 3 sonunda docs/diagrams klasörüne toplu eklenecektir.)\*\*

