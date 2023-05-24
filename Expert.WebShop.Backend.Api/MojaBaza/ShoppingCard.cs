using System;
using System.Collections.Generic;

namespace Expert.WebShop.Backend.Api.MojaBaza;

public partial class ShoppingCard
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string OrderedByName { get; set; } = null!;

    public string OrderedByEmail { get; set; } = null!;

    public string OrderId { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
