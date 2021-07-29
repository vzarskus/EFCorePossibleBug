using System;
using System.Linq;

namespace EFBugReproduction
{
    internal class Program
    {
        private static void Main()
        {
            // * Used before the 20210728124648_ScoreComponents migration is applied to
            // * insert one item into db.
            using (var context = new OffersContext())
            {
                Offer offer = context.Offers.FirstOrDefault();
                if (offer == null)
                {
                    var newOffer = new Offer(14);
                    context.Add(newOffer);
                    context.SaveChanges();
                }
            }

            using (var context = new OffersContext())
            {
                var offer = context.Offers.FirstOrDefault();

                if (offer != null)
                {
                    try
                    {
                        // ! Uncomment (step 3)
                        // offer.UpdateOfferScoreComponents(51, DeliveryType.Auto);
                        context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Here goes the exception: ");
                        Console.WriteLine(e);
                    }
                }
            }
        }
    }
}