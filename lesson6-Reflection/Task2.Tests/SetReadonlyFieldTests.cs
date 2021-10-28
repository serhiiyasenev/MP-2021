using System;
using NUnit.Framework;
using Task2.Tests.Entities;

namespace Task2.Tests
{
	[TestFixture]
	public class SetReadonlyFieldTests
	{
		const string FieldValue = "FieldValue";

		[Test]
		public void SetReadonlyField_should_set_Field_for_parent()
		{
			var parent = new Parent();

			parent.SetReadOnlyField("Field", FieldValue);

			Assert.That(parent.Field, Is.EqualTo(FieldValue));
		}

		[Test]
		public void SetReadonlyField_should_set_Field_for_child()
		{
			var child = new Child();

			child.SetReadOnlyField("Field", FieldValue);

			Assert.That(child.Field, Is.EqualTo(FieldValue));
		}

		[Test]
		public void SetReadonlyField_should_set_ChildField_for_child()
		{
			var child = new Child();

			child.SetReadOnlyField("ChildField", FieldValue);

			Assert.That(child.ChildField, Is.EqualTo(FieldValue));
		}

		[Test]
		public void SetReadonlyField_should_throw_on_invalid_field_name()
		{
			const string notExistingFieldName = "NotExistingField";

			var parent = new Parent();

			Assert.That(() =>
				{
					parent.SetReadOnlyField("NotExistingField", FieldValue);
				},
				Throws.Exception
					.With.Message.EqualTo($"The field with name {notExistingFieldName} was not found."));
		}
	}
}
