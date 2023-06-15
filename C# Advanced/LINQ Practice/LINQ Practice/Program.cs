using LINQ_Practice.Data;
using LINQ_Practice.Models;
using System.Xml.Linq;

using BlogContext context = new();

Console.WriteLine("Example 1");

/*
var posts = from post in context.Posts
            join user in context.Users
            on post.UserId equals user.Id
            select new
            {
                Id = post.Id,
                Content = post.Content,
                Username = user.Username,
                CreatedAt = post.CreatedAt,

            };
*/

var posts = context.Posts.Join(
        context.Users,
        post => post.UserId,
        user => user.Id,
        (post, user) => new
        {
            Id = post.Id,
            Content = post.Content,
            Username = user.Username,
            CreatedAt = post.CreatedAt,
        }

    );

foreach (var item in posts)
{
    Console.WriteLine("*****************");
    Console.WriteLine(item.Id);
    Console.WriteLine(item.Content);
    Console.WriteLine(item.Username);
    Console.WriteLine(item.CreatedAt);
}

Console.WriteLine("Example 2");

var users = context.Users.ToList();

/*
var posts2 = from user in users
             orderby user.Username
             group user by user.Username[0];
*/

var posts2 = users.OrderBy(u => u.Username).GroupBy(u => u.Username[0]);

foreach (var item in posts2)
{
    Console.WriteLine("\nGroup key " + item.Key);
    Console.WriteLine("*****************");
    foreach (var item1 in item)
    {
        Console.WriteLine(item1.Username);
        Console.WriteLine(item1.Email);
    }
}
