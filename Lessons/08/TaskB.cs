using System;
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

        [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
        class BarAttribute : Attribute
        {
        }
    }

    static class EnumExtensions
    {
        public static TAttribute GetEnumValueAttribute<TAttribute>(this object enumValue) where TAttribute : Attribute
        {
            if (!(enumValue is Enum))
            {
                throw new ArgumentException("not enum");
            }

            var memberInfo = enumValue.GetType().GetMember(enumValue.ToString());

            if (memberInfo != null)
            {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(TAttribute), false);

                if(attributes.Any())
                {
                    return (TAttribute)attributes[0];
                }
            }

            return null;
        }
    }

}