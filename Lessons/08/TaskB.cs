using System;
using System.Linq;
using System.Reflection;
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
            Assert.Throws<ArgumentException>(() => new object().GetEnumValueAttribute<FooAttribute, TestEnum>());
        }

        [Fact]
        public void GetEnumValueAttribute_ForValueWithoutAttributes_ShouldReturnNull()
        {
            var enumValue = TestEnum.ValueWithoutAttributes;
            var result = enumValue.GetEnumValueAttribute<FooAttribute, TestEnum>();

            Assert.Null(result);
        }

        [Fact]
        public void GetEnumValueAttribute_ForValueWithDifferentAttribute_ShouldReturnNull()
        {
            var enumValue = TestEnum.ValueWithBar;
            var result = enumValue.GetEnumValueAttribute<FooAttribute, TestEnum>();

            Assert.Null(result);
        }

        [Fact]
        public void GetEnumValueAttribute_ForValueWithFoo_ShouldReturnFooAttributeInstance()
        {
            var enumValue = TestEnum.ValueWithFoo;
            var result = enumValue.GetEnumValueAttribute<FooAttribute, TestEnum>();

            Assert.IsType<FooAttribute>(result);
        }

        public enum TestEnum
        {
            ValueWithoutAttributes,
            [Foo]
            ValueWithFoo,
            [Bar]
            ValueWithBar
        };

        [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
        class FooAttribute : Attribute
        {
        }

        class BarAttribute : Attribute
        {
        }
    }

    public static class EnumExtensions
    {
        public static TAttribute GetEnumValueAttribute<TAttribute, EnumType>(this object enumValue) where TAttribute : Attribute
        {
            if (!enumValue.GetType().IsEnum)
            {
                throw new ArgumentException();
            }

            var value = (EnumType)enumValue;
            var memberInfo = typeof(EnumType).GetMember(value.ToString()).FirstOrDefault();

            if (memberInfo != null)
            {
                return memberInfo.GetCustomAttributes(typeof(TAttribute))
                            .Cast<TAttribute>()
                            .FirstOrDefault();
            }

            return null;
        }
    }

}