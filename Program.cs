using System;
using System.Linq;

namespace EFBugReproduction
{
    internal class Program
    {
        private static void Main()
        {
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