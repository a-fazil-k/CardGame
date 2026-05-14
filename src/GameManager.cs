using System;
using System.Collections.Generic;

namespace CardGame
{
    // Kart tipleri için Enum - (Raporla uyumlu olması için metin yerine Enum kullanıyoruz)
    public enum CardType { Kaleci, Defans, Forvet }

    // --- TEMEL KART SINIFI ---
    public abstract class Card 
    {
        public string Name { get; set; } = string.Empty;
        public string PlacedPosition { get; set; } = string.Empty; 
        public float BasePower { get; set; }
        
        public abstract string GetCardRole(); 
        
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
            Card newCard = type switch 
            {
                CardType.Kaleci => new GoalkeeperCard(),
                CardType.Defans => new DefenderCard(),
                CardType.Forvet => new StrikerCard(),
                _ => throw new ArgumentException("Gecersiz kart tipi!")
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
            if (this.PlacedPosition != this.GetCardRole())
            {
                power *= 0.6f; // Mevki cezası
            }
            return power;
        }
    }

    // --- FAZ 3: STRATEGY ---
    public interface IWinningStrategy { bool IsMatchWon(float power); }
    public class StandardWinStrategy : IWinningStrategy { public bool IsMatchWon(float p) => p > 100; }

    // --- FAZ 3: OBSERVER ---
    public interface IMatchObserver { void OnMatchEnded(float power, bool result); }
    public class MatchLogger : IMatchObserver 
    { 
        public void OnMatchEnded(float p, bool r) => Console.WriteLine($"[LOG] Mac sonucu raporlandi. Guc: {p}, Galibiyet: {r}"); 
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
            var p1 = CardFactory.CreateCard(CardType.Forvet, "Oyuncu 1", 80);
            p1.PlacedPosition = "Defans"; 
            _playerCards.Add(new PositionPenaltyDecorator(p1));

            var p2 = CardFactory.CreateCard(CardType.Kaleci, "Oyuncu 2", 90);
            p2.PlacedPosition = "Kaleci"; 
            _playerCards.Add(new PositionPenaltyDecorator(p2));
        }

        public void PlayMatch()
        {
            float totalPower = 0;
            foreach (var card in _playerCards) totalPower += card.GetPower();
            
            bool result = _strategy.IsMatchWon(totalPower);
            Console.WriteLine($"Mac Sonuclandi. Toplam Guc: {totalPower}");
            
            foreach (var obs in _observers) obs.OnMatchEnded(totalPower, result);
        }
    }

    // ANA MOTOR SINIFI
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

    // CI/CD Icin Gerekli Giris Noktasi (Program.Main olmazsa Exit Code 1 hatasi alinir)
    public class Program
    {
        public static void Main(string[] args)
        {
            GameManager gm = new GameManager();
            gm.Start();
        }
    }
}
