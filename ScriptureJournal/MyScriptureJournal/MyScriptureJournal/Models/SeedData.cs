using Microsoft.EntityFrameworkCore;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MyScriptureJournalContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MyScriptureJournalContext>>()))
        {
            if (context == null || context.Entry == null)
            {
                throw new ArgumentNullException("Null MyScriptureJournalContext");
            }

            // Look for any movies.
            if (context.Entry.Any())
            {
                return;   // DB has been seeded
            }

            context.Entry.AddRange(
                new MyScriptureJournal.Models.Entry
                {
                    Book = "2 Nephi",
                    Chapter = 25,
                    Verses = "26",
                    Date = DateTime.Parse("2021-2-12"),
                    Annotation = "Problaby the verse that repeat the word 'Christ' more times on all the scriptures."
                },
                new MyScriptureJournal.Models.Entry
                {
                    Book = "1 Nephi",
                    Chapter = 3,
                    Verses = "7",                 
                    Date = DateTime.Parse("2009-3-16"),
                    Annotation = "The most know verse of the Book of Mormon."
                },
               new MyScriptureJournal.Models.Entry
                                {
                                    Book = "Enos",
                                    Chapter = 1,
                                    Verses = "",
                                    Date = DateTime.Parse("2022-10-23"),
                                    Annotation = "This book teaches about the power of praying."
                                },
                new MyScriptureJournal.Models.Entry
                {
                    Book = "3 Nephi",
                    Chapter = 11,
                    Verses = "8 - 10",
                    Date = DateTime.Parse("2000-3-19"),
                    Annotation = "Christ appear to the nephites the first time."
                }

            ); ;
            context.SaveChanges();
        }
    }
}