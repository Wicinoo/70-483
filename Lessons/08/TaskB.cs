using System;
using System.Linq;
using FluentAssertions;
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

        enum TestEnum
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

    static class EnumExtensions
    {
        public static TAttribute GetEnumValueAttribute<TAttribute>(this object enumValue)
        {
            var enumValueCasted = enumValue as Enum;
            if (enumValueCasted == null)
            {
                throw new ArgumentException($"{nameof(enumValue)} must be Enum");
            }

            var type = enumValueCasted.GetType();
            var memberInfo = type.GetMember(enumValueCasted.ToString()).First();
            var attribute = Attribute.GetCustomAttribute(memberInfo, typeof(TAttribute)).As<TAttribute>();

            return attribute;
        }
    }

}