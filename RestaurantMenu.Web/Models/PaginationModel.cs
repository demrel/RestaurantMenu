﻿

namespace RestaurantMenu.Web.Models;

public class PaginationModel 
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
