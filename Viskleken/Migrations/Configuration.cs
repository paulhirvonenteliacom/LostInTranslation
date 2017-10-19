namespace Viskleken.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Viskleken.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Viskleken.Models.VisklekenContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Viskleken.Models.VisklekenContext context)
        {
            context.Languages.AddOrUpdate(p => p.Id, new Language
            {
                Id = 1,
                Name = "1. Amhariska, javanesiska, gaeliska, kanaresiska, urdu"
            });

            context.Languages.AddOrUpdate(p => p.Id, new Language
            {
                Id = 2,
                Name = "2. Hebreiska, chichewa, gujarati, hindi, maori"
            });

            context.Languages.AddOrUpdate(p => p.Id, new Language
            {
                Id = 3,
                Name = "3. Polska, hmong, xhosa, pashto, isländska"
            });

            context.Languages.AddOrUpdate(p => p.Id, new Language
            {
                Id = 4,
                Name = "4. Swahili, igbo, frisiska, tadzjikiska, sindhi"
            });

            context.Languages.AddOrUpdate(p => p.Id, new Language
            {
                Id = 5,
                Name = "5. Marathi, kirgiziska, tamil, esperanto, danska"
            });

            context.SaveChanges();
        }
    }
}
