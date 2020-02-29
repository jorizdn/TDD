using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using TDDUnitTestImplementation.Data;

namespace TDDUnitTestImplementation
{
    [TestFixture] 
    public class Test
    {
        private readonly VendingMachine _vendingMachine = new VendingMachine();
        private Products _products = new Products();

        [Test, Sequential]
        public void WhenUserPutsMoney_ShouldAcceptMoneyFromTheSequence([Values(100, 50, 20, 10, 5, 1, 0.25)] double money)
        {
            var isValidated = _vendingMachine.ValidateMoney(money);

            Assert.IsTrue(isValidated);
        }

        [Test, Sequential]
        public void WhenUserPutsMoney_ShouldNotAcceptMoneyFromTheSequence([Values(200, 0.50, 500, 1000, 0.10)] double money)
        {
            var isValidated = _vendingMachine.ValidateMoney(money);

            Assert.IsFalse(isValidated);
        }

        [Test]
        public void WhenUserBuysAProduct_ThenMoneyShouldBeEnoughForTheProduct()
        {
            var money = new List<double>(){10,20,20};
            var productId = 3;
            var product = _vendingMachine.BuyProduct(money, productId);

            Assert.GreaterOrEqual(product.Change, 0);
        }

        [Test]
        public void WhenUserBuysAProductAndHadInsufficientMoney_ThenMessageWillInformTheUserAboutTheError()
        {
            var money = new List<double>() { 5,10 };
            var productId = 3;
            var product = _vendingMachine.BuyProduct(money, productId);

            Assert.IsNotNull(product.Message);
        }

        [Test]
        public void WhenUserBuysAProductAndHadEnoughMoney_ThenMessageIsNull()
        {
            var money = new List<double>() { 100 };
            var productId = 3;
            var product = _vendingMachine.BuyProduct(money, productId);

            Assert.IsNull(product.Message);
        }

        [Test]
        public void WhenTransactionIsCancelled_ThenMoneyWillBeRefunded()
        {
            var money = new List<double>() {10, 20, 20};
            var result = _vendingMachine.CancelRequest(true, money);

            Assert.AreEqual(money.Sum(), result);
        }

        [Test, Sequential]
        public void WhenUserBuys_ThenItAllowToBuyProductsOnTheSequence([Values(1,2,3,4,5,6)] int productId)
        {
            var money = new List<double>(){100,100,100,100,100};
            var result = _vendingMachine.BuyProduct(money, productId);

            Assert.IsTrue(result.IsSuccessful);
        }
    }
}
