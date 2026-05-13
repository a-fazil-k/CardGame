using System;
using System.Collections.Generic;

// FAZ 0: Spagetti Kod
public class GameManager 
{
    // Sorun 1: Kart modeli, veri tutma ve oyun mantığı hepsi aynı sınıfa tıkıştırılmış.
    public class Card 
    {
        public string Name;
        public string PlayerType; // "Kaleci", "Defans", "Forvet"
        public string PlacedPosition; 
        public float Power;
    }

    public List<Card> PlayerCards = new List<Card>();

    public void CalculateResult() 
    {
        float playerTotalPower = 0;

        // Sorun 2: Tüm güç hesaplama ve ceza mantığı devasa bir foreach/if-else yığını içinde.
        foreach (var card in PlayerCards) 
        {
            float currentPower = card.Power;

            // Sorun 3: Genişlemeye kapalı. "Orta Saha" eklense buraya yeni if eklenecek.
            if (card.PlayerType == "Forvet" && card.PlacedPosition != "Forvet") 
            {
                currentPower = card.Power * 0.6f; 
            }
            else if (card.PlayerType == "Defans" && card.PlacedPosition != "Defans") 
            {
                currentPower = card.Power * 0.6f;
            }
            else if (card.PlayerType == "Kaleci" && card.PlacedPosition != "Kaleci") 
            {
                currentPower = card.Power * 0.6f; 
            }
            
            playerTotalPower += currentPower;
        }
        
        Console.WriteLine("Oyuncunun Toplam Gücü: " + playerTotalPower);
    }
}