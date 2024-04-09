using PizzaAndWings.Models;
using PizzaAndWings.Dto;
namespace PizzaAndWings.Controllers
{
    public class UsersApi
    {
        public static void Map(WebApplication app)
        {
            //check user's uid in the database
            app.MapPost("/api/checkUser/{uid}", (PizzaAndWingsDbContext db, string uid, CheckUserDto newUserDto) =>
            {
                User checkUser = db.Users.FirstOrDefault(user => user.Uid == uid);
                if (checkUser != null)
                {
                    return Results.Ok(checkUser);
                }
               
                User newUser = new User();
                newUser.Uid = newUserDto.Uid;
                newUser.Name = newUserDto.Name;
                newUser.Email = newUserDto.Email;

                db.Users.Add(newUser);
                db.SaveChanges();

                return Results.Ok(newUser);
            });
        }

    }
}
