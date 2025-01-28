using libraryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace libraryManagementSystem.Services
{
    public class LibraryService
    {
        private readonly List<LibraryItem> _items = new(); // #7 Collections: Storing library items.
        private readonly List<User> _users = new();

        // #8 Exception Handling: Handling null inputs or invalid operations.
        public void AddBook(LibraryItem book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book), "Book cannot be null.");
            _items.Add(book);
            LogToFile($"Book added: {book.GetDescription()}"); // #9 File Handling: Logging actions to a file.
        }

        public void AddUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user), "User cannot be null.");
            _users.Add(user);
            LogToFile($"User added: {user.GetDetails()}");
        }

        public LibraryItem GetBookById(int id)
        {
            var book = _items.FirstOrDefault(b => b.Id == id);
            if (book == null) throw new KeyNotFoundException("Book not found.");
            return book;
        }

        public void BorrowBook(int bookId, int userId)
        {
            var book = GetBookById(bookId);
            var user = _users.FirstOrDefault(u => u.Id == userId);
            if (user == null) throw new KeyNotFoundException("User not found.");

            if (user is Member) // #10 Type Checking: Checking the type of user at runtime.
            {
                Console.WriteLine($"{book.Title} has been borrowed by {user.Name}.");
                LogToFile($"Borrowed: {book.Title} by {user.Name}");
            }
            else
            {
                throw new InvalidOperationException("Only members can borrow books.");
            }
        }

        private void LogToFile(string message)
        {
            var logFilePath = "LibraryLog.txt";
            File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}{Environment.NewLine}");
        }
    }
}
