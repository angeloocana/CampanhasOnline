using System;
using System.Collections.Generic;
using System.Data;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Indexing;

namespace TotalOnDemand.CampanhasOnline
{
    public class Migrations : DataMigrationImpl
    {

        public int Create()
        {
            // Creating table ProductPartRecord
            SchemaBuilder.CreateTable("ProductPartRecord", table => table
                .ContentPartRecord()
                .Column("Sku", DbType.String)
                .Column("Price", DbType.Single)
            );



            return 1;
        }

        public int UpdateFrom1()
        {
            ContentDefinitionManager.AlterPartDefinition("ProductPart",
              builder => builder.Attachable());
            return 2;
        }

        public int UpdateFrom2()
        {
            ContentDefinitionManager.AlterTypeDefinition("Product", cfg => cfg
              .WithPart("CommonPart")
              .WithPart("RoutePart")
              .WithPart("BodyPart")
              .WithPart("ProductPart")
              .WithPart("CommentsPart")
              .WithPart("TagsPart")
              .WithPart("LocalizationPart")
              .Creatable()
              .Indexed());
            return 3;
        }

        public int UpdateFrom3()
        {
            ContentDefinitionManager.AlterTypeDefinition("Movie", builder =>
                builder.WithPart("CommonPart")
              .WithPart("TitlePart")
              .WithPart("AutoroutePart")
              );
            return 4;
        }

        public int UpdateFrom4()
        {
            ContentDefinitionManager.AlterTypeDefinition("Angelo", builder =>
                builder.WithPart("CommonPart")
              .WithPart("TitlePart")
              .WithPart("AutoroutePart")
              );
            return 5;
        }

        public int UpdateFrom5()
        {
            ContentDefinitionManager.AlterTypeDefinition("Angelo", builder =>
                builder.WithPart("BodyPart", partBuilder => 
                    partBuilder.WithSetting("BodyTypePartSettings.Flavor","text"))
                .WithPart("AutoroutePart", partBuilder => 
                    partBuilder
                        .WithSetting("AutorouteSettings.AllowCustomPattern", "true")
                        .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "false")
                        .WithSetting("AutorouteSettings.PatternDefinitions", "[{Name: 'Angelo Title', Pattern: 'angelo/{Content.Slug}', Description: 'angelo/angelo-title'}]")
                        .WithSetting("AutorouteSettings.DefaultPatternIndex", "0"))
                .Creatable()
                .Draftable()
              );
            return 6;
        }

        public int UpdateFrom6() {
            SchemaBuilder.CreateTable("AngeloPartRecord", table =>
                table.ContentPartRecord()
                    .Column<string>("IMDB_ID")
                    .Column<int>("YearReleased")
                    .Column<string>("Rating", col => col.WithLength(4)));
            return 7;
        }
    }
}