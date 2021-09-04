using Domain.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Product
    {
        [JsonProperty]
        public int Id { get; set; }
        [JsonProperty]
        public string Name { get; set; }
        [JsonProperty]
        public string Description { get; set; }
        [JsonProperty]
        public int Quantity { get; set; }
        [JsonProperty]
        public decimal Price { get; set; }
        [JsonProperty]
        public DateTime CaducityDate { get; set; }
        [JsonProperty]
        public MeasurementUnit MeasuUnit { get; set; }

        public class ProductPriceComparer : IComparer<Product>
        {
            public int Compare(Product e1, Product e2)
            {
                if (e1 == null || e2 == null)
                {
                    throw new ArgumentException("Error, los objetos no puedn ser null.");
                }
                if (e1.Price> e2.Price)
                {
                    return 1;
                }
                else if (e1.Price < e2.Price)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

    }
}
