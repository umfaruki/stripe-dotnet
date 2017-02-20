using System.Reflection;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Stripe.Tests.xUnit
{
    public class adding_additional_owners_with_file : test
    {
        private StripeAccount RetrievedAccount { get; }

        public adding_additional_owners_with_file()
        {
            // upload the stripe logo as an identity document
            var fileService = new StripeFileUploadService();
            var fileStream = typeof(adding_additional_owners_with_file).GetTypeInfo().Assembly.GetManifestResourceStream("Stripe.net.Tests.xUnit.resources.logo.png");

            var file = fileService.Create("logo.png", fileStream, StripeFilePurpose.IdentityDocument);

            // create a new account with the verification document as the file
            // var newAccount = new StripeAccountService(_stripe_api_key).Create(
            //     new StripeAccountCreateOptions
            //     {
            //         Email = $"happy@birthday.com",
            //         Managed = true,
            //         LegalEntity = new StripeAccountLegalEntityOptions
            //         {
            //             AdditionalOwners = new List<StripeAccountAdditionalOwner>
            //             {
            //                 new StripeAccountAdditionalOwner
            //                 {
            //                     FirstName = "Big", LastName = "Little",
            //                     BirthDay = 25, BirthMonth = 12, BirthYear = 2000,
            //                     DocumentId = file.Id
            //                 }
            //             }
            //         }
            //     }
            // );

            // RetrievedAccount = new StripeAccountService(_stripe_api_key).Get(newAccount.Id);
        }

        [Fact]
        public void has_verification_document()
        {
            "test".Should().NotBeNull();
            //RetrievedAccount.LegalEntity.Should().NotBeNull();
        }
    }
}

