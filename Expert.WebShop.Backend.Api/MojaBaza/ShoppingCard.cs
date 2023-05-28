using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Expert.WebShop.Backend.Api.MojaBaza;

public partial class ShoppingCard
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string OrderedByName { get; set; } = null!;

    public string OrderedByEmail { get; set; } = null!;

    public string OrderId { get; set; } = null!;
    public int NumberOfItems { get; set; }

    public float PricePerProduct { get; set; }
    public int ProductDiscount { get; set; }
    public float TotalAmmount { get; set; }
    public bool IsPayed { get; set; }
    public bool IsDelivered { get; set; }

    [JsonIgnore]
    public virtual Product Product { get; set; } = null!;
}