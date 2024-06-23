﻿using Domain;
using FluentAssertions;
using FunctionalProgrammingKit;
using NUnit.Framework;

namespace Testing.Domain.Primitives;

[TestFixture]
public static partial class MoneySpecs
{
    private const decimal positive_amount = 123.4567m;
    private const decimal negative_amount = -123.4567m;

    private static object a_positive_decimal_value()
    {
        return positive_amount;
    }    
    
    private static object a_negative_decimal_value()
    {
        return negative_amount;
    }

    private static object converting_to_money(object amount)
    {
        return Money.New((decimal)amount);
    }    
    
    private static object multiplying_by_two(object money)
    {
        return ((ValueObject<Money>)money).Bind(m => m.Multiply(2));
    }

    private static void money_is_formatted_to_2_dp(object money)
    {
        var value = ((ValueObject<Money>)money).Match().Value;
        value.ToString().Should().Be($"{Math.Round(positive_amount, 2)}");
        ((decimal)value).Should().Be(positive_amount);
    }    
    
    private static void the_amount_is_doubled(object money)
    {
        var value = ((ValueObject<Money>)money).Match().Value;
        value.ToString().Should().Be($"{Math.Round(positive_amount * 2, 2)}");
        ((decimal)value).Should().Be(positive_amount * 2);
    }  
}