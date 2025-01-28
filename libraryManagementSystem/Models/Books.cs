using System;

namespace libraryManagementSystem.Models
{
    public enum BookGenre // #6 Enum: Represents book genres for categorization.
    {
        Fiction,
        NonFiction,
        Science,
        History,
        Biography
    }

    public abstract class LibraryItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public BookGenre Genre { get; set; }

        // #5 Abstraction: Abstract methods force derived classes to provide implementation.
        public abstract string GetDescription();

        // #3 Constructor: Base constructor to initialize common properties.
        protected LibraryItem(int id, string title, string author, BookGenre genre)
        {
            Id = id;
            Title = title;
            Author = author;
            Genre = genre;
        }
    }

    public class PhysicalBook : LibraryItem
    {
        public int Pages { get; set; }

        public PhysicalBook(int id, string title, string author, BookGenre genre, int pages)
            : base(id, title, author, genre)
        {
            Pages = pages;
        }

        // #5 Abstraction (continued): Implementing the abstract method in the child class.
        public override string GetDescription() => $"{Title} by {Author} - {Pages} pages ({Genre}).";
    }

    public class EBook : LibraryItem
    {
        public double FileSizeMB { get; set; }

        public EBook(int id, string title, string author, BookGenre genre, double fileSize)
            : base(id, title, author, genre)
        {
            FileSizeMB = fileSize;
        }

        // #5 Abstraction (continued): Another implementation of the abstract method.
        public override string GetDescription() => $"{Title} by {Author} - {FileSizeMB} MB ({Genre}).";
    }
}
