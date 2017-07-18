using System;
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
            if (enumValue.GetType().BaseType != typeof(Enum))
            {
                throw new ArgumentException();
            }

            var type = enumValue.GetType();
            var memInfo = type.GetMember(enumValue.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(TAttribute), true);

            if (attributes.Length == 0)
            {
                return default(TAttribute);
            }

            return ((TAttribute)attributes[0]);
        }
    }

}