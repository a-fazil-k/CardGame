using System;
using System.Collections.Generic;

// 1. ÜRÜN SOYUTLAMASI: Tüm kartların ortak özellikleri
public abstract class Card 
{
    public string Name { get; set; }
    public string PlacedPosition { get; set; }
    public float BasePower { get; set; }
    
    // Her kart kendi tipini bilecek
    public abstract string GetPlayerType(); 
}

// 2. SOMUT ÜRÜNLER: Alt kart sınıfları
public class GoalkeeperCard : Card 
{
    public override string GetPlayerType() => "Kaleci";
}

public class DefenderCard : Card 
{
    public override string GetPlayerType() => "Defans";
}

public class StrikerCard : Card 
{
    public override string GetPlayerType() => "Forvet";
}

// 3. FABRİKA SINIFI (Factory Method): Kart üretim merkezi
public class CardFactory 
{
    public static Card CreateCard(string type, string name, float basePower) 
    {
        Card newCard = type switch 
        {
            "Kaleci" => new GoalkeeperCard(),
            "Defans" => new DefenderCard(),
            "Forvet" => new StrikerCard(),
            _ => throw new ArgumentException("Geçersiz kart tipi!")
        };

        newCard.Name = name;
        newCard.BasePower = basePower;
        return newCard;
    }
}

// ARTIK TEMİZLENMİŞ OYUN YÖNETİCİSİ
public class GameManager 
{
    public List<Card> PlayerCards = new List<Card>();

    public void StartMatch() 
    {
        // GameManager artık "nasıl" üretileceğini bilmiyor, sadece Fabrika'dan istiyor.
        PlayerCards.Add(CardFactory.CreateCard("Forvet", "Oyuncu 1", 80));
        PlayerCards.Add(CardFactory.CreateCard("Kaleci", "Oyuncu 2", 90));
        PlayerCards.Add(CardFactory.CreateCard("Defans", "Oyuncu 3", 75));
    }
}