using System;
using System.Collections.Generic;

// Kart tipleri için Enum (Tip güvenliği sağlandı - Raporla uyumlu)
public enum CardType { Kaleci, Defans, Forvet }

// --- TEMEL KART SINIFI ---
public abstract class Card 
{
    public string Name { get; set; }
    public string PlacedPosition { get; set; } // Oynatıldığı mevki
    public float BasePower { get; set; }
    
    public abstract string GetCardRole(); // Kartın asıl mevkisi
    
    public virtual float GetPower() 
    {
        return BasePower;
    }
}

public class GoalkeeperCard : Card { public override string GetCardRole() => "Kaleci"; }
public class DefenderCard : Card { public override string GetCardRole() => "Defans"; }
public class StrikerCard : Card { public override string GetCardRole() => "Forvet"; }

// --- FAZ 1: FACTORY METHOD ---
public class CardFactory 
{
    public static Card CreateCard(CardType type, string name, float basePower) 
    {
        // Raporumuzda belirttiğimiz gibi seçim işlemini Enum ile yapıyoruz
        Card newCard = type switch 
        {
            CardType.Kaleci => new GoalkeeperCard(),
            CardType.Defans => new DefenderCard(),
            CardType.Forvet => new StrikerCard(),
            _ => throw new ArgumentException("Geçersiz kart tipi!")
        };
        newCard.Name = name;
        newCard.BasePower = basePower;
        return newCard;
    }
}

// --- FAZ 2: DECORATOR ---
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
    public override string GetCardRole() => _card.GetCardRole();
    public override float GetPower() => _card.GetPower();
}

public class PositionPenaltyDecorator : CardDecorator
{
    public PositionPenaltyDecorator(Card card) : base(card) { }

    public override float GetPower()
    {
        float power = base.GetPower();
        // Mevki cezası kontrolü
        if (this.PlacedPosition != this.GetCardRole())
        {
            power *= 0.6f;
        }
        return power;
    }
}

// --- FAZ 3: STRATEGY & OBSERVER ---
public interface IWinningStrategy { bool IsMatchWon(float power); }
public class StandardWinStrategy : IWinningStrategy { public bool IsMatchWon(float p) => p > 100; }

public interface IMatchObserver { void OnMatchEnded(float power, bool result); }
public class MatchLogger : IMatchObserver 
{ 
    public void OnMatchEnded(float p, bool r) => Console.WriteLine($"[LOG] Güç: {p}, Sonuç: {(r ? "Galibiyet" : "Mağlubiyet")}"); 
}

// --- FAZ 2: FACADE ---
public class MatchFacade
{
    private List<Card> _playerCards = new List<Card>();
    private IWinningStrategy _strategy = new StandardWinStrategy();
    private List<IMatchObserver> _observers = new List<IMatchObserver>();

    public void AddObserver(IMatchObserver obs) => _observers.Add(obs);
    public void SetStrategy(IWinningStrategy s) => _strategy = s;

    public void SetupTeam()
    {
        // Enum kullanarak güvenli üretim
        var player1 = CardFactory.CreateCard(CardType.Forvet, "Oyuncu 1", 80);
        player1.PlacedPosition = "Defans"; 
        _playerCards.Add(new PositionPenaltyDecorator(player1));

        var player2 = CardFactory.CreateCard(CardType.Kaleci, "Oyuncu 2", 90);
        player2.PlacedPosition = "Kaleci"; 
        _playerCards.Add(new PositionPenaltyDecorator(player2));
    }

    public void PlayMatch()
    {
        float totalPower = 0;
        foreach (var card in _playerCards) totalPower += card.GetPower();
        
        bool result = _strategy.IsMatchWon(totalPower);
        Console.WriteLine($"Maç bitti. Toplam Güç: {totalPower}");
        
        foreach (var obs in _observers) obs.OnMatchEnded(totalPower, result);
    }
}

public class GameManager 
{
    public void Start() 
    {
        MatchFacade match = new MatchFacade();
        match.AddObserver(new MatchLogger());
        match.SetupTeam();
        match.PlayMatch();
    }
}
