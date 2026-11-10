namespace Terrasoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Text.RegularExpressions;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Sync;

	#region Class: ContactExtensions
	
	public static class ContactExtensions
	{

		#region Methdos: Public

			/// <summary>
			/// Fills <paramref name="contact"/> "Full name" field using <paramref name="converter"/>.
			/// </summary>
			/// <param name="contact">Contact instance.</param>
			/// <param name="converter"><see cref="IContactFieldConverter"/> implementation.</param>
			public static void FillNameField(this Contact contact, IContactFieldConverter converter) {
			if (converter == null) {
				return;
			}
			contact.Name = converter.GetContactName(new ContactSgm {
				Surname = contact.Surname,
				GivenName = contact.GivenName,
				MiddleName = contact.MiddleName
				});
		}

		/// <summary>
		/// Fills <paramref name="contact"/> "First name", "Last name", "Middle name" fields using
		/// <paramref name="converter"/>.
		/// </summary>
		/// <param name="contact">Contact instance.</param>
		/// <param name="converter"><see cref="IContactFieldConverter"/> implementation.</param>
		public static void FillSgmFields(this Contact contact, IContactFieldConverter converter) {
			if (converter == null) {
				return;
			}
			ContactSgm contactSgm = converter.GetContactSgm(contact.Name);
			contact.Surname = contactSgm.Surname;
			contact.GivenName = contactSgm.GivenName;
			contact.MiddleName = contactSgm.MiddleName;
		}

		#endregion

	}
	
	#endregion
	
}

