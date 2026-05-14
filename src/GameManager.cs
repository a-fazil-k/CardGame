using System;
using System.Collections.Generic;

// --- FAZ 1: YARATIMSAL (FACTORY METHOD) ---
public abstract class Card 
{
    public string Name { get; set; }
    public string PlacedPosition { get; set; }
    public float BasePower { get; set; }
    
    public abstract string GetPlayerType(); 
    
    // Güç hesaplaması için eklendi (Decorator burada devreye girecek)
    public virtual float GetPower() 
    {
        return BasePower;
    }
}

public class GoalkeeperCard : Card { public override string GetPlayerType() => "Kaleci"; }
public class DefenderCard : Card { public override string GetPlayerType() => "Defans"; }
public class StrikerCard : Card { public override string GetPlayerType() => "Forvet"; }

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

// --- FAZ 2: YAPISAL ÖRÜNTÜLER ---

// 1. DECORATOR (Dekoratör): Mevki cezalarını if-else'siz dinamik hesaplamak için
public abstract class CardDecorator : Card
{
    protected Card _card;

    public CardDecorator(Card card)
    {
        _card = card;
        this.Name = card.Name;
        this.PlacedPosition = card.PlacedPosition;
        this.BasePower = card.BasePower;
    }

    public override string GetPlayerType() => _card.GetPlayerType();
    public override float GetPower() => _card.GetPower();
}

public class PositionPenaltyDecorator : CardDecorator
{
    public PositionPenaltyDecorator(Card card) : base(card) { }

    public override float GetPower()
    {
        float power = base.GetPower();
        
        // Kendi mevkisinde oynamıyorsa %60 ceza alır (Spagetti if-else'ler yerine tek kural)
        if (this.PlacedPosition != this.GetPlayerType())
        {
            power *= 0.6f;
        }
        return power;
    }
}

// 2. FACADE (Cephe): Karmaşık oyun motorunu tek ve basit bir arayüze indirme
public class MatchFacade
{
    private List<Card> _playerCards = new List<Card>();

    public void SetupTeam()
    {
        // Kartları Fabrikadan üretip, anında Dekoratör ile sarmalıyoruz
        var player1 = CardFactory.CreateCard("Forvet", "Oyuncu 1", 80);
        player1.PlacedPosition = "Defans"; // Yanlış mevki (Ceza alacak)
        _playerCards.Add(new PositionPenaltyDecorator(player1));

        var player2 = CardFactory.CreateCard("Kaleci", "Oyuncu 2", 90);
        player2.PlacedPosition = "Kaleci"; // Doğru mevki (Tam güç)
        _playerCards.Add(new PositionPenaltyDecorator(player2));
    }

    public void CalculateAndShowResult()
    {
        float totalPower = 0;
        foreach (var card in _playerCards)
        {
            // Artık ceza hesabını GameManager yapmıyor, kart kendi gücünü hesaplıyor!
            totalPower += card.GetPower(); 
        }
        Console.WriteLine("Takımın Toplam Gücü: " + totalPower);
    }
}

// ARTIK TERTEMİZ OLAN ANA SINIF
public class GameManager 
{
    public void StartMatch() 
    {
        // GameManager sadece Facade'a emir veriyor. Gerisiyle ilgilenmiyor.
        MatchFacade match = new MatchFacade();
        match.SetupTeam();
        match.CalculateAndShowResult();
    }
}