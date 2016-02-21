using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Hermes.DataAccess;

namespace Hermes.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20160215152718_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Hermes.Blogs.Blog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTimeOffset>("DateCreated");

                    b.Property<DateTimeOffset>("DateModified");

                    b.Property<DateTimeOffset>("DatePublished");

                    b.Property<string>("Slug");

                    b.Property<string>("Title");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Hermes.Blogs.BlogPost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("BlogId");

                    b.Property<string>("Content");

                    b.Property<DateTimeOffset>("DateCreated");

                    b.Property<DateTimeOffset>("DateModified");

                    b.Property<DateTimeOffset>("DatePublished");

                    b.Property<string>("Slug");

                    b.Property<string>("Title");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Hermes.Blogs.BlogPost", b =>
                {
                    b.HasOne("Hermes.Blogs.Blog")
                        .WithMany()
                        .HasForeignKey("BlogId");
                });
        }
    }
}
