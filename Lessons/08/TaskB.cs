using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Lessons._08
{
    /// <summary>
    /// Implement GetEnumValueAttribute() extension method to get an attribute defined for an enum value.
    /// Make all tests passed.
    /// Make multiple usage of FooAttribute unallowed.
    /// </summary>
    public class TaskB
    {
        [Fact]
        public void GetEnumValueAttribute_ForNonEnumValue_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new object().GetEnumValueAttribute<FooAttribute>());
        }

        [Fact]
        public void GetEnumValueAttribute_ForValueWithoutAttributes_ShouldReturnNull()
        {
            var enumValue = TestEnum.ValueWithoutAttributes;
            var result = enumValue.GetEnumValueAttribute<FooAttribute>();

            Assert.Null(result);
        }

        [Fact]
        public void GetEnumValueAttribute_ForValueWithDifferentAttribute_ShouldReturnNull()
        {
            var enumValue = TestEnum.ValueWithBar;
            var result = enumValue.GetEnumValueAttribute<FooAttribute>();

            Assert.Null(result);
        }

        [Fact]
        public void GetEnumValueAttribute_ForValueWithFoo_ShouldReturnFooAttributeInstance()
        {
            var enumValue = TestEnum.ValueWithFoo;
            var result = enumValue.GetEnumValueAttribute<FooAttribute>();

            Assert.IsType<FooAttribute>(result);
        }

        public enum TestEnum
        {
            ValueWithoutAttributes,
            [Foo]
            ValueWithFoo,
            [Bar]
            ValueWithBar
        }

        [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
        class FooAttribute : Attribute
        {
        }

        class BarAttribute : Attribute
        {
        }
    }

    internal static class EnumExtensions
    {
        public static TAttribute GetEnumValueAttribute<TAttribute>(this object enumValue)
        {
            var memberInfo = typeof (TaskB.TestEnum).GetMember(enumValue.ToString())
                .FirstOrDefault();

            if (memberInfo != null)
            {
                var attributesOnValue = memberInfo.GetCustomAttributes(typeof (TAttribute), false);

                if (attributesOnValue.Any())
                {
                    return (TAttribute) attributesOnValue.FirstOrDefault();
                }
                else
                {
                    return default(TAttribute);
                }

            }

            throw new ArgumentException();
        }
    }

}