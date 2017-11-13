namespace LostInTranslation.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using LostInTranslation.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<LostInTranslation.Models.LostInTranslationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LostInTranslation.Models.LostInTranslationContext context)
        {
            context.Languages.AddOrUpdate(p => p.Id, new Language
            {
                Id = 1,
                Name = "1. Latin, Javanese, Scots Gaelic, Kannada, Urdu"
            });

            context.Languages.AddOrUpdate(p => p.Id, new Language
            {
                Id = 2,
                Name = "2. Hebrew, Chichewa, Gujarati, Hindi, Maori"
            });

            context.Languages.AddOrUpdate(p => p.Id, new Language
            {
                Id = 3,
                Name = "3. Polish, Hmong, Xhosa, Pashto, Icelandic"
            });

            context.Languages.AddOrUpdate(p => p.Id, new Language
            {
                Id = 4,
                Name = "4. Swahili, Igbo, Frisian, Tajik, Sindhi"
            });

            context.Languages.AddOrUpdate(p => p.Id, new Language
            {
                Id = 5,
                Name = "5. Marathi, Kyrgyz, Tamil, Esperanto, Danish"
            });

            context.SaveChanges();
        }
    }
}
