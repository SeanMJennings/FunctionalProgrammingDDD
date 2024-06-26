﻿using Application;
using FluentAssertions;
using FunctionalProgrammingKit;
namespace Testing;

internal static class VerbsAndNouns
{
    internal static object Given(Func<object> func)
    {
        return func.Invoke();
    }

    internal static object And(this object previousResult, Func<object, object> func)
    {
        return func.Invoke(previousResult);
    }    
    
    internal static object And(this object _, Func<object> func)
    {
        return func.Invoke();
    }
    
    internal static void And(this object previousResult, Action<object> func)
    {
        func.Invoke(previousResult);
    }    

    internal static object When(this object previousResult, Func<object, object> func)
    {
        return func.Invoke(previousResult);
    }    
    
    internal static object When(this object _, Func<object> func)
    {
        return func.Invoke();
    }

    internal static object Then(this object previousResult, Func<object, object> func)
    {
        return func.Invoke(previousResult);
    }    
    
    internal static void Then(this object previousResult, Action<object> func)
    {
        func.Invoke(previousResult);
    }    
    
    internal static void Then(this object _, Action func)
    {
        func.Invoke();
    }
    
    internal static string WhenValidatingTheValueObject<T>(this object previousResult, Func<object, object> func)
    {
        return string.Join("", ((ValueObject<T>)func.Invoke(previousResult)).Match().Errors[0].Message);
    }    
    
    internal static string WhenValidatingTheEntity<T>(this object previousResult, Func<object, object> func)
    {
        return string.Join("", ((ReturnWrapper<T>)func.Invoke(previousResult)).Errors[0].Message);
    }    
    
    internal static string WhenValidatingTheResponseDto<T>(this object previousResult, Func<object, object> func)
    {
        return string.Join("", ((ResponseDto<T>)func.Invoke(previousResult)).Errors.ToArray()[0].Message);
    }
    
    internal static void ThenInforms(this string actualMessage, string expectedMessage)
    {
        actualMessage.Should().Be(expectedMessage);
    }
}