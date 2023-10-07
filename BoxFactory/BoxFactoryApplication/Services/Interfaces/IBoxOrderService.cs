﻿using BoxFactoryDomain.Entities;

namespace BoxFactoryApplication.Services.Interfaces;

public interface IBoxOrderService
{

    Task<List<BoxOrder>> GetAllOrders();

    Task<bool> DeleteOrderById(int orderId);

}