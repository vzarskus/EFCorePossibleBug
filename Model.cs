using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFBugReproduction
{
    public class OffersContext : DbContext
    {
        public DbSet<Offer> Offers { get; set; }

        public string DbPath { get; private set; }

        public OffersContext()
        {
            var path = Environment.CurrentDirectory;
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}/offers.db";
        }

        // Configure SQLite db
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

    public class Offer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; private set; }

        public ScoreVO Score { get; private set; }

        private Offer()
        { }

        public Offer(double initialScore)
        {
            Id = Guid.NewGuid();
            Score = new ScoreVO(initialScore);
        }

        // ! Uncomment (step 3)
        // public void UpdateOfferScoreComponents(DeliveryType deliveryType)
        // {
        //     Score.CalculateDeliveryTypeScore(deliveryType);
        // }
    }

    // ! Comment out (step 2)
    [Owned]
    public class ScoreVO
    {
        [Column(TypeName = "FLOAT(53)")]
        public double Score { get; private set; }

        private ScoreVO()
        { }

        public ScoreVO(double initialScore)
        {
            Score = initialScore;
        }
    }

    // ! Uncomment (step 3)
    // [Owned]
    // public class ScoreVO
    // {
    //     [Column(TypeName = "FLOAT(53)")]
    //     public double Score { get; private set; }

    //     public double DeliveryTypeScore { get; private set; }

    //     private ScoreVO()
    //     { }

    //     public ScoreVO(double initialScore)
    //     {
    //         Score = initialScore;
    //     }

    //     protected void UpdateScore()
    //     {
    //         Score += DeliveryTypeScore;
    //     }

    //     public void CalculateDeliveryTypeScore(DeliveryType deliveryType)
    //     {
    //         DeliveryTypeScore = deliveryType == DeliveryType.Auto ? 100 : 0;
    //         UpdateScore();
    //     }
    // }

    public enum DeliveryType
    {
        Manual = 0,
        Auto = 1
    }
}