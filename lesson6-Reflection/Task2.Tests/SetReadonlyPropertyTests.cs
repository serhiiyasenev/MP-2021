using NUnit.Framework;
using Task2.Tests.Entities;

namespace Task2.Tests
{
	[TestFixture]
	public class SetReadonlyPropertyTests
	{
		[Test]
		public void SetReadonlyProperty_should_set_Property_for_parent()
		{
			var parent = new Parent();

			parent.SetReadOnlyProperty("Property", 10);

			Assert.That(parent.Property, Is.EqualTo(10));
		}

		[Test]
		public void SetReadonlyProperty_should_set_Property_for_child()
		{
			var child = new Child();

			child.SetReadOnlyProperty("Property", 20);

			Assert.That(child.Property, Is.EqualTo(20));
		}

		[Test]
		public void SetReadonlyProperty_should_set_ChildProperty_for_child()
		{
			var child = new Child();

			child.SetReadOnlyProperty("ChildProperty", 30);

			Assert.That(child.ChildProperty, Is.EqualTo(30));
		}

		[Test]
		public void SetReadonlyProperty_should_throw_on_invalid_field_name()
		{
			const string notExistingPropertyName = "NotExistingProperty";

			var parent = new Parent();

			Assert.That(() => parent.SetReadOnlyProperty(notExistingPropertyName, 10),
				Throws.Exception
					.With.Message.EqualTo($"The property with name {notExistingPropertyName} was not found."));
		}
	}
}
