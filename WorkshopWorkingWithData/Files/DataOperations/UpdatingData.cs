using System;
using System.Globalization;
using Terrasoft.Common;
using Terrasoft.Core;
using Terrasoft.Core.DB;
using Terrasoft.Core.Entities;

namespace WorkshopWorkingWithData.Files.DataOperations
{
    internal sealed class UpdatingData
    {
        readonly UserConnection UserConnection;
        public UpdatingData(UserConnection userConnection)
        {
            UserConnection = userConnection;
        }

        internal string UpdateContactUpdate(Guid ContactId, string NewName)
        {
            const string tableName = "Contact";

            Select select = new Select(UserConnection)
				.Top(1)
				.Column("Name")
				.From(tableName).WithHints(new NoLockHint())
				.Where("Id")
				.IsEqual(Column.Parameter(ContactId)) as Select;
            string OldName = select.ExecuteScalar<string>();

            Update update = new Update(UserConnection, tableName)
                .Set("Name", Column.Parameter($"{OldName} {NewName}"))
                .Where("Id").IsEqual(Column.Parameter(ContactId)) as Update;
            return (update.Execute() == 1) ? "Updated":"Failed";
        }

        internal string UpdateContactEsq(Guid ContactId, string NewName)
        {
            const string tableName = "Contact";
            EntitySchema contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName(tableName);
            Entity contact = contactSchema.CreateEntity(UserConnection);
            contact.FetchFromDB(ContactId);


			if (contactSchema.Columns.FindByName("Name").IsLocalizable)
			{
				LocalizableString locName = new LocalizableString();
				CultureInfo en_us = new CultureInfo("en-US");
				CultureInfo ro_ro = new CultureInfo("ro-RO");


				locName.SetCultureValue(en_us, "Name in English");
				locName.SetCultureValue(ro_ro, "Name in RO");

				contact.SetColumnValue("Name", locName);
			}
			else
			{
				contact.SetColumnValue("Name", contact.GetTypedColumnValue<string>("Name")+" "+NewName);
			}



			


			if (contact.UpdateInDB())
                return "Updated";
            return "Failed";
        }
    }
}
