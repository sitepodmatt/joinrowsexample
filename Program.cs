using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AnimalFarmDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");
            var optionBuilder = new DbContextOptionsBuilder<DatabaseContext>();
            optionBuilder.UseMySql("Server=localhost;Database=animals;Uid=YOURUSERNAME;Pwd=YOURPASSWORD;");
            var lf = LoggerFactory.Create(builder => builder.AddConsole());
            optionBuilder.UseLoggerFactory(lf);

            using (var ctx = new DatabaseContext(optionBuilder.Options))
            {
                ctx.Database.EnsureDeleted();
                ctx.Database.EnsureCreated();

                var entity = new Animal();

                for (int i = 0; i < 500; i++)
                {
                    entity.TextAttributes.Add(new TextAttribute()
                    {
                        Name = "key" + i,
                        Value = "v" + i,
                    });
                    entity.IntAttributes.Add(new IntAttribute()
                    {
                        Name = "key" + i,
                        Value = i
                    });
                    entity.DateTimeAttributes.Add(new DateTimeAttribute()
                    {
                        Name = "key" + i,
                        Value = DateTime.Now.AddDays(i)
                    });
                }

                Console.WriteLine("Saving");
                ctx.Animals.Add(entity);
                ctx.SaveChanges();
                Console.WriteLine("Saved");
            }

            using (var ctx = new DatabaseContext(optionBuilder.Options))
            {
                Console.WriteLine("Fetching");

                var fetched = ctx.Animals
                    .Include(x => x.TextAttributes)
                    .Include(x => x.IntAttributes)
                    .Include(x => x.DateTimeAttributes).ToList();

                foreach (var item in fetched)
                {
                    Console.WriteLine(item.Id);
                }

                Console.WriteLine("Fetched");
            }

            Console.WriteLine("Done.");
        }
    }
}
