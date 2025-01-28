using System;

namespace libraryManagementSystem.Models
{
    public enum UserRole // #6 Enum
    {
        Admin,
        Member
    }

    public class User
    {
        // #1 Encapsulation: Fields are private, ensuring data cannot be accessed directly.
        // Access is provided via public properties, which include validation logic.
        private int _id;
        private string _name;
        private string _email;

        // #2 Properties: Used to encapsulate and validate data.
        public int Id
        {
            get => _id;
            set
            {
                if (value <= 0) throw new ArgumentException("ID must be greater than 0.");
                _id = value;
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value)) throw new ArgumentException("Name cannot be empty.");
                _name = value;
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (!value.Contains("@")) throw new ArgumentException("Invalid email address.");
                _email = value;
            }
        }

        public UserRole Role { get; set; } // #6 Enum: Represents user roles such as Admin or Member.

        // #3 Constructor: Used to initialize the object with required data.
        public User(int id, string name, string email, UserRole role)
        {
            Id = id;
            Name = name;
            Email = email;
            Role = role;
        }

        // #4 Polymorphism: This method can be overridden in derived classes.
        public virtual string GetDetails() => $"{Name} ({Role}) - Email: {Email}";
    }

    public class Admin : User
    {
        // #3 Constructor (continued): Child classes use base keyword to call the parent class constructor.
        public Admin(int id, string name, string email)
            : base(id, name, email, UserRole.Admin) { }

        // #4 Polymorphism (continued): Overriding the base method to provide a custom implementation.
        public override string GetDetails() => $"{base.GetDetails()} [Admin Privileges]";
    }

    public class Member : User
    {
        public int BorrowLimit { get; private set; } = 5; // #2 Properties (continued): Read-only property.

        public Member(int id, string name, string email)
            : base(id, name, email, UserRole.Member) { }

        // #4 Polymorphism (continued): Another example of method overriding.
        public override string GetDetails() => $"{base.GetDetails()} - Borrow Limit: {BorrowLimit}";
    }
}
