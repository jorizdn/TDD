using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDDUnitTestImplementation.Data;
using TDDUnitTestImplementation.Model;

namespace TDDUnitTestImplementation
{
    public class VendingMachine
    {
        public bool ValidateMoney(double money)
        {
            var data = new Products();
            return data.Money.Contains(money);
        }

        public Product GetProduct(int productId)
        {
            var products = new Products();
            return products.data.FirstOrDefault(x => x.Id == productId);
        }

        public double GetChange(double total, double amount)
        {
            return total - amount;
        }

        public ChangeResult BuyProduct(List<double> money, int productId)
        {
            var result = new ChangeResult(){IsSuccessful = true};
            var data = new Products();
            var isValidated = true;
            money.ForEach(x =>
            {
                if (!ValidateMoney(x))
                {
                    isValidated = false;
                }
            });

            if (isValidated)
            {
                var totalMoney = money.Sum();
                var product = GetProduct(productId);
                if (product != null)
                {
                    var change = GetChange(totalMoney, product.Value);
                    result.Change = change;
                    result.Product = product;
                    if (change < 0)
                    {
                        result = new ChangeResult(){IsSuccessful = false, Message = "Insufficient money"};
                    }
                }
                else
                {
                    result.IsSuccessful = false;
                }
            }
            else
            {
                result.IsSuccessful = false;
            };

            return result;
        }

        public double CancelRequest(bool isCancelled, List<double> money)
        {
            if (isCancelled)
            {
                return money.Sum();
            }

            return 0;
        }
    }
}
