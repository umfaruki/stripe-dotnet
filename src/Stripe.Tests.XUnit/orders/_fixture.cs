using System;

namespace Stripe.Tests.Xunit
{
    public class orders_fixture : IDisposable
    {
        public StripeOrderCreateOptions OrderCreateOptions { get; }
        //public StripeSourceUpdateOptions SourceUpdateOptions { get; }

        public StripeOrder Order { get; }
        //public StripeSource SourceUpdated { get; }
        //public StripeSource SourceRetrieved { get; }

        public orders_fixture()
        {
            OrderCreateOptions = new StripeOrderCreateOptions
            {
                Currency = "usd"
            };

            //SourceUpdateOptions = new StripeSourceUpdateOptions
            //{
            //    Owner = new StripeSourceOwner
            //    {
            //        Email = "hendrix@jimmy.com"
            //    }
            //};

            var service = new StripeOrderService(Cache.ApiKey);
            Order = service.Create(OrderCreateOptions);
            //SourceUpdated = service.Update(Source.Id, SourceUpdateOptions);
            //SourceRetrieved = service.Get(Source.Id);
        }

        public void Dispose()
        {
            // not implemented :(
            // new StripeSourceService(Cache.ApiKey).Delete(Source.Id);
        }
    }
}
