﻿namespace NewFeatures;

public interface IOrder
{
    DateTime Purchased { get; }
    decimal Cost { get; }
}