using System.Collections;
using System.IO.Pipes;
using System.Linq;
using System.Xml.Linq;

namespace Algorithms
{
    public class Product
    {
        public int Weight;
        public float Cost;
    }

    public class BackpackTask
    {
        private class Track
        {
            public Product product;
            public Track Previous;
            public float Price = 0;

            public Track(Product p, Track prev, float price)
            {
                product = p;
                Previous = prev;
                Price = price;
            }
        }

        public static Tuple<float, List<Product>> GetMaxBenefit(List<Product> products, int maxWeight)
        {
            maxWeight++;

            var func = new Track[maxWeight];

            for (int M = 0; M < maxWeight; M++)
            {
                var array = products.Select(p => 
                M >= p.Weight
                ? new Track(p, func[M - p.Weight], func[M - p.Weight].Price + p.Cost) 
                : new Track(null, null, 0));

                var maxPrice = new Track(null, null, float.MinValue);
                foreach (var item in array)
                {
                    if (item.Price > maxPrice.Price)
                        maxPrice = item;
                }

                func[M] = maxPrice;

                //func[M] = products.Select(p => M >= p.Weight ? func[M - p.Weight] + p.Cost : 0).Max();
            }


            var productsList = new List<Product>();

            var end = func.Last();
            while (end.product != null)
            {
                productsList.Add(end.product);
                end = end.Previous;
            }

            productsList.Reverse();

            return Tuple.Create(func.Last().Price, productsList);
        }


    }
}
